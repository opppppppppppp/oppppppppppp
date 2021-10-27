using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace Battleships.Models.Observer
{
    interface ISubject
    {
        void Register(IObserver observer);
        void Unregister(IObserver observer);
        void Notify(string playerUID, WebSocketSessionManager ServerSession);

    }
}
