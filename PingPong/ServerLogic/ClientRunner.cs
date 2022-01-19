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
        private Socket _client;

        public ClientRunner(Socket client)
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
            byte[] bytes = new byte[1024];
            int bytesRec = _client.Receive(bytes);
            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }

        public Task SendToClient(byte[] toSend)
        {
            _client.Send(toSend);
            return Task.CompletedTask;
        }
    }
}
