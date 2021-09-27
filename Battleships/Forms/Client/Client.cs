using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WebSocketSharp;



namespace Battleships.Forms
{
    class Client
    {
        public static Game game;
        public static WebSocket ws;
        static  string ip_addr;
        private static Random random = new Random();
        static string user_id;

        public static void Connect(string ip_address)
        {
            user_id = RandomString();
            ip_addr = ip_address;
            ws = new WebSocket($"ws://{ip_address}/Connection");
            ws.OnMessage += OnMessage;
            ws.Connect();
            ws.Send("Connected");
        }

        public static WebSocket Positions(string ip_address)
        {
            ip_addr = ip_address;
            ws = new WebSocket($"ws://{ip_address}/Positions");
            ws.OnMessage += OnPosMessage;
            ws.Connect();
            return ws;
        } 
        public static WebSocket Response(string ip_address)
        {
            ip_addr = ip_address;
            ws = new WebSocket($"ws://{ip_address}/Response");
            ws.OnMessage += OnResponseMessage;
            ws.Connect();
            return ws;
        }

        private static void OnResponseMessage(object sender, MessageEventArgs e)
        {
            var items = JsonConvert.DeserializeObject<List<string>>(e.Data);
            if(items[0] == "True")
            game.markHitField(items[1]);
        }

        public static  string RandomString()
        {
            const string chars = "qwertyuiopasdfghjklzxcvbnm,./']ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 12)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }




        private static void OnPosMessage(object sender, MessageEventArgs e)
        {
            var items = JsonConvert.DeserializeObject<List<string>>(e.Data);

            if (items[1] != user_id)
                game.checkPlayerPosition(items[0]);

        }


        private static void OnMessage(object sender, MessageEventArgs e)
        {
            if(Convert.ToInt32(e.Data) == 2)
            {
                
                game = new Game(ip_addr);
                game.setUserId(user_id);
                game.setPlayerPositionAsEnemy();
                game.ShowDialog();
            }   

        }

        

        private static void ShowExceptionDetails(Exception exception)
        {
            MessageBox.Show(exception.Message, exception.TargetSite.ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
