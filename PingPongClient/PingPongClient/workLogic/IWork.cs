using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.workLogic
{
    interface IWork<T>
    {
        public void UseServerRespond(byte [] respond);

        public List<T> ServerJobArguments(); 
    }
}
