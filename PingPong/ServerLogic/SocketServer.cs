using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ServerLogic
{
    public class SocketServer : Iserver
    {
        private TcpListener _listener;
        
        public SocketServer(string ip , string port)
        {
            IPAddress ipAd = IPAddress.Parse(ip);
            TcpListener _listner = new TcpListener(ipAd, int.Parse(ip));


        }
        public Task ListenForClients()
        {
            _listener.Start();
            TcpClient client = null;
            Console.WriteLine("waiting for clients");
            for (int i = 0; i <= 10; i++)
            {
                client = _listener.AcceptTcpClient();
                IClient a = new ClientRunner(client);
                a.RunClient().Start();
            }
            return Task.CompletedTask;
        }

        public async Task RunServer()
        {
            await ListenForClients();
            
        }


    }
}
