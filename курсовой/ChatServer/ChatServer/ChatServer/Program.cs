using System;
using System.Threading;

namespace ChatServer
{
    class Program
    {
        private static ServerObject _server; // сервер
        private static Thread _listenThread; // потока для прослушивания
        static void Main(string[] args)
        {
            try
            {
                _server = new ServerObject();
                _listenThread = new Thread(_server.Listen);
                _listenThread.Start(); //старт потока
            }
            catch (Exception ex)
            {
                _server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
