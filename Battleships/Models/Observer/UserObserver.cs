using Battleships.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Battleships.Models.Observer
{
    class UserObserver : IObserver
    {
        private string ID { get; set; }
        public UserObserver(string user_id)
        {
            this.ID = user_id;
        }
        public string GetId()
        {
            return ID;
        }
        public void PlayerTurn(string userUID, WebSocketSessionManager ServerSession)
        {
           ServerSession.Broadcast(userUID); 
        }
    }
}
