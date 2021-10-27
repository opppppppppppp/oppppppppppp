using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace Battleships.Models.Observer
{
    interface IObserver
    {
        void PlayerTurn(string playUID, WebSocketSessionManager ServerSession);
    }
}
