using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace Battleships.Models.Observer
{
    class TurnSubject : ISubject
    {
        private HashSet<IObserver> _observers = new HashSet<IObserver>();

        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string _playUID, WebSocketSessionManager ServerSession)
        {
            _observers.ToList().ForEach(o => o.PlayerTurn(_playUID, ServerSession));
        }
    }
}
