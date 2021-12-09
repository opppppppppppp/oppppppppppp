using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace Battleships.Models.Mediator
{
    public interface AbstractChatroom
    {
        void SendMessage(string[] messagedata, Player user, WebSocketSessionManager Session);
        void RegisterUser(Player user);
    }
}
