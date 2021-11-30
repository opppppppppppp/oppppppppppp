using Battleships.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;


namespace Battleships.Models.Template_Method
{
    public class TurnConnector : ConnectionAccessor
    {
        public WebSocket player_turn { get; set; }
        public static Player player { get; set; }
        public static Game game { get; set; }

        public override void Connect(string ip_address)
        {
            var wsf = new WebSocketFacadeProxy(ip_address, "Turn");
            player_turn = wsf.Connect(OnTurnMessage);
        }

        static void OnTurnMessage(object sender, MessageEventArgs e)
        {
            string uid = JsonConvert.DeserializeObject<String>(e.Data);
            if (uid == player.getUID())
            {
                game.Facade.SetAttackButtonStatus(false);
                game.Facade.SetSpecialButtonStatus(false);
            }
            else
            {
                game.Facade.SetAttackButtonStatus(true);
                game.Facade.SetSpecialButtonStatus(true);
            }
            Debug.WriteLine($"*CLIENT* Client with ID:{uid} just attacked, his TURN is over! ");

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
            return player_turn;
        }
    }
}
