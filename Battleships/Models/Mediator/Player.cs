using Battleships.Models.Mediator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
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

        public override void Receive(object sender, MessageEventArgs e, Game game)
        {
            //Console.WriteLine(this.UID + ": Received Message:" + message);
            var items = JsonConvert.DeserializeObject<List<string>>(e.Data);
            var uid = items[1];
            var message = items[0];
            game.Facade.WriteMessageToChatBox(message, uid);
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
