using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Battleships.Models
{
    public abstract class ConnectionAccessor
    {
        public abstract void Positions(string ip_address);
        public abstract void Response(string ip_address);
        public abstract void Complete(string ip_address);
        public abstract void Turn(string ip_address);
        public void Connect(string ip_address)
        {
            Positions(ip_address);
            Response(ip_address);
            Complete(ip_address);
            Turn(ip_address);
        }
    }
}
