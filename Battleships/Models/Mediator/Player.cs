using Battleships.Models.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace Battleships.Models
{
    public class Player : Participant
    {
        private string UID { get; set; }
        public Player(AbstractChatroom chatroom, string id = null) : base(chatroom)
        {
            if (id == null)
                UID = Guid.NewGuid().ToString();
            else
                UID = id;
        }

        public override void Receive(string message)
        {
            //Console.WriteLine(this.UID + ": Received Message:" + message);
            
        }
        public override void Send(string[] messagedata, WebSocketSessionManager Session)
        {
            chatroom.SendMessage(messagedata, this, Session);
        }

        public string getUID()
        {
            return UID;
        }
            

    }
}
