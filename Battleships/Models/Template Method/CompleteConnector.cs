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
    public class CompleteConnector : ConnectionAccessor
    {
        public WebSocket complete_socket { get; set; }
        public static Player player { get; set; }
        public static Game game { get; set; }
        public override void Connect(string ip_address)
        {
            var wsf = new WebSocketFacadeProxy(ip_address, "Complete");
            complete_socket = wsf.Connect(OnCompleteMessage);
        }
        private static void OnCompleteMessage(object sender, MessageEventArgs e)
        {
            string uid = JsonConvert.DeserializeObject<String>(e.Data);
            game.Facade.Completed(uid);
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
            return complete_socket;
        }

    }
}
