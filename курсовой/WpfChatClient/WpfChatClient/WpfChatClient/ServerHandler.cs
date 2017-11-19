using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfChatClient.SerializationTypes;

namespace WpfChatClient
{
    internal class ServerHandler : IDisposable
    {
        private static readonly TcpClient Client = new TcpClient();
        private static NetworkStream _stream;
        private readonly string _host;
        private readonly int _port;

        public ServerHandler(string host,int port)
        {
            _host = host;
            _port = port;
        }

        // получение сообщений
        public  string ReceiveMessage2()
        {
                try
                {
                    var data = new byte[64]; // буфер для получаемых данных
                    var builder = new StringBuilder();
                    do
                    {
                        var read = _stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, read));
                    } while (_stream.DataAvailable);
                    return builder.ToString();
                }
                catch
                {  
                    Dispose();
                    return "Подключение прервано!\n";
                }
            
        }

        public void SendMessage(string message)
        {
            var data = Encoding.Unicode.GetBytes(message);
            _stream.Write(data, 0, data.Length);
        }

        public void SendData(Shape Object)
        {
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(_stream,Object);
        }

        public void CloseClientConnection()
        {
            if (Client.Connected)
            {
                const string closeConnectionMessage = "Close connection message";
                var data = Encoding.Unicode.GetBytes(closeConnectionMessage);
                _stream.Write(data, 0, data.Length);
            }
            Dispose();
        }

        public string ConnectClient(string username)
        {
            try
            {
                Client.Connect(_host, _port); //подключение клиента
                _stream = Client.GetStream(); // получаем поток
                var message = username;
                var data = Encoding.Unicode.GetBytes(message);
                _stream.Write(data, 0, data.Length);
                // запускаем новый поток для получения данных
                return "Добро пожаловать, " + username + Environment.NewLine;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void Dispose()
        {
            if (_stream != null)
                _stream.Close();//отключение потока
            if (Client != null)
                Client.Close();//отключение клиента
            Environment.Exit(0); //завершение процесса
        }
    }
}
