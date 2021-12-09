using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Models.ChainPattern;
using WebSocketSharp.Server;

namespace Battleships.Models.Mediator
{
    public class Chatroom : AbstractChatroom
    {
        private MessageHandler _messageHandler = MessageHandler.DefaultMessageHandler();
        private List<Player> usersList = new List<Player>();
        public void RegisterUser(Player user)
        {
            if(!usersList.Contains(user))
                usersList.Add(user);
        }
        public void SendMessage(string[] messagedata, Player user, WebSocketSessionManager Session)
        {
            foreach (var u in usersList)
            {
                if (u.getUID() != user.getUID())
                {
                    Message message = new Message(messagedata[1]);
                    
                    Session.Broadcast(JsonConvert.SerializeObject(
                        new string[] {
                            messagedata[0],
                            _messageHandler.HandleMessage(message)
                        }
                    ));
                }
            }
        }
    }
}
