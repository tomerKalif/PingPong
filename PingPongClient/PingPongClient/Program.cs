using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System;

namespace PingPongClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 2121);
            Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(localEndPoint);
            string toSend = Console.ReadLine();
            sender.Send(Encoding.ASCII.GetBytes(toSend));
            byte[] bytes = new byte[1024];
            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
         Encoding.ASCII.GetString(bytes, 0, bytesRec));

        }
    }
}
