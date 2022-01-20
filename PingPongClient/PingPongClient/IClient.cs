using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace PingPongClient
{
    interface IClient
    {
        public void SendToServer(byte [] toSend);

        public void ConnectToServer(string ip , string port);

        public byte[] ReciveFromClient();
    }
}
