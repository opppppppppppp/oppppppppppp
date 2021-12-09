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
    public class ResponseConnector : ConnectionAccessor
    {
        public WebSocket response_socket { get; set; }
        public static Player player { get; set; }
        public static Game game { get; set; }
        public override void Connect(string ip_address)
        {
            var wsf = new WebSocketFacadeProxy(ip_address, "Response");
            response_socket = wsf.Connect(OnResponseMessage);
        }

        private static void OnResponseMessage(object sender, MessageEventArgs e)
        {
            var items = JsonConvert.DeserializeObject<List<string>>(e.Data);
            string uid = items[0];
            int ship_index = Convert.ToInt32(items[1]);
            bool hit_status = Convert.ToBoolean(items[2]);

            game.Facade.UpdateHitShips(ship_index, uid, hit_status);
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
            return response_socket;
        }
    }
}
