using Battleships.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Observer
{
    class UserObserver : IObserver
    {
        private string ID { get; set; }
         WebSocket turn_socket;
         Game _game;

        public UserObserver(string user_id)
        {
            turn_socket = Client.Turn(Constants.ip_address);
            this.ID = user_id;
        }

        public string GetId()
        {
            return ID;
        }
        public void PlayerTurn(string userUID)
        {
            turn_socket.Send(userUID);
        }
    }
}
