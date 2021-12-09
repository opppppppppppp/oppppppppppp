using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace Battleships.Models.Mediator
{
    public class Chatroom : AbstractChatroom
    {
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
                    Session.Broadcast(JsonConvert.SerializeObject(messagedata));
                }
            }
        }
    }
}
