using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Battleships.Models.Mediator
{
    public abstract class Participant
    {
        protected AbstractChatroom chatroom;
        public Participant(AbstractChatroom chatrm)
        {
            this.chatroom = chatrm;
        }
        public abstract void Send(string[] messagedata, WebSocketSessionManager Session);
        public abstract void Receive(object sender, MessageEventArgs e, Game game);
    }
}
