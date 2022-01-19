using System;
using System.Threading.Tasks;
using ServerLogic;

namespace PingPongExercise
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SocketServer a = new SocketServer("2121");
            await a.RunServer();
        }
    }
}
