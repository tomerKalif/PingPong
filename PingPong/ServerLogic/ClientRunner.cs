using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ServerLogic.PersonLogic;

namespace ServerLogic
{
    class ClientRunner : IClient
    {
        private TcpClient _client;
        private NetworkStream _networkStream;
        private StreamWriter _writer;



        public ClientRunner(TcpClient client)
        {
            _client = client;
        }
        public async Task RunClient()
        {
            Console.WriteLine("new client detected");
            // i think this can be replaced , will do if i have time
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            while (true)
            {
                string name = await ReciveFromClient();
                string age = await ReciveFromClient();
                Person a = new Person(name, int.Parse(age));
                bf.Serialize(ms, a);
                await SendToClient(ms.ToArray());
            }
        }

        public async Task<string> ReciveFromClient()
        {
            Console.WriteLine("entered recive from client");
            byte[] buffer = new byte[_client.ReceiveBufferSize];
            int bytesRead = _networkStream.Read(buffer, 0, _client.ReceiveBufferSize);
            return Encoding.ASCII.GetString(buffer, 0, bytesRead);
        }

        public Task SendToClient(byte[] toSend)
        {
            _networkStream.Write(toSend , 0 , _client.ReceiveBufferSize);
            return Task.CompletedTask;
        }
    }
}
