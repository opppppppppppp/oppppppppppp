using Battleships.Forms;
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
        public abstract void Connect(string ip_address);
        public abstract void SetGame(Game game);
        public abstract WebSocket GetSocket();
        public abstract void SetPlayer(Player player);
        //public abstract void OnMessageReceive();
        public void Run(string ip_address, Game game, Player player)
        {
            SetGame(game);
            SetPlayer(player);
            Connect(ip_address);
            //OnMessageReceive();
        }
    }
}
