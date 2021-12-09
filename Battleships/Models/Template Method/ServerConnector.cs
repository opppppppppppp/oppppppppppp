using Battleships.Forms;
using Battleships.Models.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Battleships.Models.Template_Method
{
    public class ServerConnector : ConnectionAccessor
    {
        public WebSocket server_socket { get; set; }
        public static Player player { get; set; }
        public static Game game { get; set; }
        public static Chatroom chatroom { get; set; }

        public override void Connect(string ip_address)
        {
            chatroom = new Chatroom();
            player = new Player(chatroom);
            var wsf = new WebSocketFacadeProxy(ip_address, "Connection");
            server_socket = wsf.Connect(OnRoomCreate, player.getUID());
            //position_socket = Client.Positions(ip_address);
        }

        static void OnRoomCreate(object sender, MessageEventArgs e)
        {
            string[] data = e.Data.Split(':');

            var user_count = Convert.ToInt32(data[1]);
            var uid = data[0];
            //Debug.WriteLine($"*CLIENT* Client : {uid}");
            SetFirstTurnSettings(user_count, uid);
        }

        private static void SetFirstTurnSettings(int user_count, string uid)
        {
            //ServerConnector sObj = new ServerConnector();
            if (user_count == 2)
                game = new Game(player);
            if (user_count == 2 && player.getUID() == uid)
            {
                //game.Facade.setUID(player.getUID());
                game.Facade.SetAttackButtonStatus(true);
                game.Facade.SetSpecialButtonStatus(true);
                game.ShowDialog();

            }
            else if (user_count == 2)
            {
                //game.Facade.setUID(player.getUID());
                game.Facade.SetAttackButtonStatus(false);
                game.Facade.SetSpecialButtonStatus(false);
                game.ShowDialog();
            }
        }

        public override void SetPlayer(Player pl)
        {
        }

        public override void SetGame(Game gm)
        { 
        }

        public override WebSocket GetSocket()
        {
            return server_socket;
        }

    }
}
