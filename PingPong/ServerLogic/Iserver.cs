using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerLogic
{
    interface Iserver
    {
        public Task RunServer();

        public Task ListenForClients();

        public Task ReciveFromClient(Socket client);

        public Task SendToClient(Socket client, byte toSend);
    }
}
