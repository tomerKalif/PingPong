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
        private Socket _listener;

        public SocketServer(string port)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, int.Parse(port));
            _listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _listener.Bind(localEndPoint);

        }
        public Task ListenForClients()
        {
            _listener.Listen(10);
            Socket client = null;
            Console.WriteLine("waiting for clients");
            for (int i = 0; i <= 10; i++)
            {
                client = _listener.Accept();
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
