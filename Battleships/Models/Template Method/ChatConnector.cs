using Battleships.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;


namespace Battleships.Models.Template_Method
{
    public class ChatConnector : ConnectionAccessor
    {
        public WebSocket chat_socket { get; set; }
        public static Player player { get; set; }
        public static Game game { get; set; }

        public override void Connect(string ip_address)
        {
            var wsf = new WebSocketFacadeProxy(ip_address, "Chat");
            chat_socket = wsf.Connect(OnChatMessage);
        }

        static void OnChatMessage(object sender, MessageEventArgs e)
        {
            var items = JsonConvert.DeserializeObject<List<string>>(e.Data);
            var uid = items[1];
            var message = items[0];
            game.Facade.WriteMessageToChatBox(message, uid);
            //game.Facade.ShipHitCheck(ship_index, uid);
        }

        public override void SetPlayer(Player pl)
        {
            player = pl;
        }

        public override void SetGame(Game gm)
        {
            game = gm;
        }

        public override WebSocket GetSocket()
        {
            return chat_socket;
        }
    }
}
