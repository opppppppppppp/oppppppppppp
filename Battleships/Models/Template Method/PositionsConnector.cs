using Battleships.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;


namespace Battleships.Models.Template_Method
{
    public class PositionsConnector : ConnectionAccessor
    {
        public WebSocket position_socket { get; set; }
        public static Player player { get; set; }
        public static Game game { get; set; }
        public override void Connect(string ip_address)
        {
            var wsf = new WebSocketFacadeProxy(ip_address, "Positions");
            position_socket = wsf.Connect(OnPosMessage);
            //position_socket = Client.Positions(ip_address);
        }

        private static void OnPosMessage(object sender, MessageEventArgs e)
        {

            var items = JsonConvert.DeserializeObject<List<string>>(e.Data);
            var uid = items[1];
            var ship_index = Convert.ToInt32(items[0]);

            if (uid != player.getUID())
            {
                //Debug.WriteLine("*CLIENT* Message from the Client!");
                game.Facade.ShipHitCheck(ship_index, uid);
            }
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
            return position_socket;
        }

    }
}
