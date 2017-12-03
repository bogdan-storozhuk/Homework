using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SerializationTypes;

namespace ChatServer
{
    public class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream MessageStream { get; private set; }
        protected internal NetworkStream DataStream { get; private set; }
        private string _userName;
        private readonly TcpClient _messageClient;
        private readonly TcpClient _dataClient;
        private readonly ServerObject _server; // объект сервера

        public ClientObject(TcpClient tcpMessageClient, TcpClient tcpDataClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            _messageClient = tcpMessageClient;
            _dataClient = tcpDataClient;
            _server = serverObject;
            serverObject.AddConnection(this);
        }

        public void ProcessMessages()
        {
            try
            {
                MessageStream = _messageClient.GetStream();
                // получаем имя пользователя
                var message = GetMessage();
                _userName = message;

                message = _userName + " вошел в чат";
                // посылаем сообщение о входе в чат всем подключенным пользователям
                _server.BroadcastMessage(message, Id);
                Console.WriteLine(message);
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        if (message == "Close connection message")
                        {
                            _messageClient.Close();
                        }
                        if (!_messageClient.Connected) { throw new Exception("Client connection is closed"); }
                        message = string.Format("{0}: {1}", _userName, message);
                        Console.WriteLine(message);
                        _server.BroadcastMessage(message, Id);
                    }
                    catch
                    {
                        message = string.Format("{0}: покинул чат", _userName);
                        Console.WriteLine(message);
                        _server.BroadcastMessage(message, Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                _server.RemoveConnection(Id);
                Close();
            }
        }
        public void ProcessData()
        {
            try
            {
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        DataStream = _dataClient.GetStream();
                        IFormatter formatter = new BinaryFormatter();
                        var deserializingObject = (Shape) formatter.Deserialize(DataStream);

                        if (deserializingObject is SerializationLine)
                        {
                            _server.BroadcastData(deserializingObject, Id);
                        }
                        else if (deserializingObject is SerializationEllipse)
                        {
                            _server.BroadcastData(deserializingObject, Id);
                        }
                        else if (deserializingObject is SerializationRectangle)
                        {
                            _server.BroadcastData(deserializingObject, Id);
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                _server.RemoveConnection(Id);
                Close();
            }
        }
        // чтение входящего сообщения и преобразование в строку
        private string GetMessage()
        {
            var data = new byte[64]; // буфер для получаемых данных
            var builder = new StringBuilder();
            do
            {
                var bytes = MessageStream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (MessageStream.DataAvailable);

            return builder.ToString();
        }

        // закрытие подключения
        protected internal void Close()
        {
            if (MessageStream != null)
                MessageStream.Close();
            if (_messageClient != null)
                _messageClient.Close();
            if (DataStream != null)
                DataStream.Close();
            if (_dataClient != null)
                _dataClient.Close();
        }
    }
}
