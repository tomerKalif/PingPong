using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace PingPongClient
{
    class ClientToServer : IClient
    {
        private TcpClient _connection;
        private NetworkStream _networkStream;

        public void ConnectToServer(string ip, string port)
        {
            _connection = new TcpClient(ip, int.Parse(port));
            _networkStream = _connection.GetStream();
        }

        public byte[] ReciveFromClient()
        {
            byte[] buffer = new byte[_connection.ReceiveBufferSize];
            int bytesRead = _networkStream.Read(buffer, 0, _connection.ReceiveBufferSize);
            return buffer;
        }

        public void SendToServer(byte[] toSend)
        {
            _networkStream.Write(toSend, 0, _connection.ReceiveBufferSize);
        }
    }
}
