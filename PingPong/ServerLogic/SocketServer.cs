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
                Task.Run((() => RunClient(client)));             
            }
            return Task.CompletedTask;
        }
        private async Task RunClient(Socket client)
        {
            while (true)
            {
                string ping = await ReciveFromClient(client);
                Console.WriteLine(ping);
                await SendToClient(client, Encoding.ASCII.GetBytes(ping));
            }
        }

        public async Task<string> ReciveFromClient(Socket client)
        {
           byte []  bytes = new byte[1024];
           int bytesRec = client.Receive(bytes);
           return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }

        public async Task RunServer()
        {
            await ListenForClients();
            
        }

        public Task SendToClient(Socket client, byte[] toSend)
        {
            client.Send(toSend);
            return Task.CompletedTask;
        }
    }
}
