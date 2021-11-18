using Battleships.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Battleships.Models
{
    public class Connections : ConnectionAccessor
    {
        public WebSocket position_socket { get; set; }
        public WebSocket response_socket { get; set; }
        public WebSocket complete_socket { get; set; }
        public WebSocket player_turn { get; set; }
        public override void Positions(string ip_address)
        {
            position_socket = Client.Positions(ip_address);
        }
        public override void Response(string ip_address)
        {
            response_socket = Client.Response(ip_address);
        }
        public override void Complete(string ip_address)
        {
            complete_socket = Client.Complete(ip_address);
        }
        public override void Turn(string ip_address)
        {
            player_turn = Client.Turn(ip_address);
        }
    }
}
