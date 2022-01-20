using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.workLogic
{
    class PersonWork : IWork<string>
    {
        public List<string> ServerJobArguments()
        {
            List<string> sendStuff = new List<string>();

        }

        public void UseServerRespond(byte[] respond)
        {
            throw new NotImplementedException();
        }
    }
}
