using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ServerLogic
{
    class SocketServer : Iserver
    {
        private Socket _listener;

        public SocketServer(string ip , string port)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            _listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
        public Task ListenForClients()
        {
            throw new NotImplementedException();
        }

        public Task ReciveFromClient(Socket client)
        {
            throw new NotImplementedException();
        }

        public Task RunServer()
        {
            throw new NotImplementedException();
        }

        public Task SendToClient(Socket client, byte toSend)
        {
            throw new NotImplementedException();
        }
    }
}
