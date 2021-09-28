using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using WebSocketSharp;

namespace Battleships.Forms
{
    class Client
    {
        public static Game game;
        public static WebSocket ws;
        static string ip_addr;
        private static Random random = new Random();
        static string user_id;

        /// <summary>
        /// Metodas, skirtas prisijungti prie ws://{ip_address}/Connection route.
        /// </summary>
        /// <param name="ip_address">IP Address prie kurio jungiames</param>
        public static void Connect(string ip_address)
        {
            user_id = GenerateUserID();
            ip_addr = ip_address;
            ws = new WebSocket($"ws://{ip_address}/Connection");
            ws.OnMessage += OnRoomCreate;
            ws.Connect();
            ws.Send("Connected");
        }

        /// <summary>
        /// Metodas, skirtas prisijungti prie ws://{ip_address}/Positions route.
        /// </summary>
        /// <param name="ip_address">Serveris, prie kurio jungiames</param>
        /// <returns>Grąžinamas WebSocket</returns>
        public static WebSocket Positions(string ip_address)
        {
            ip_addr = ip_address;
            ws = new WebSocket($"ws://{ip_address}/Positions");
            ws.OnMessage += OnPosMessage;
            ws.Connect();
            return ws;
        }
        /// <summary>
        /// Metodas, skirtas prisijungti prie ws://{ip_address}/Positions route.
        /// </summary>
        /// <param name="ip_address">Serveris, prie kurio jungiames</param>
        /// <returns>Grąžinamas WebSocket</returns>
        public static WebSocket Response(string ip_address)
        {
            ip_addr = ip_address;
            ws = new WebSocket($"ws://{ip_address}/Response");
            ws.OnMessage += OnResponseMessage;
            ws.Connect();
            return ws;
        }

        /// <summary>
        /// Metodas, skirtas prisijungti prie ws://{ip_address}/Complete route.
        /// </summary>
        /// <param name="ip_address">Serveris, prie kurio jungiames</param>
        /// <returns>Grąžinamas WebSocket</returns>
        public static WebSocket Complete(string ip_address)
        {
            ip_addr = ip_address;
            ws = new WebSocket($"ws://{ip_address}/Complete");
            ws.OnMessage += OnCompleteMessage;
            ws.Connect();
            return ws;
        }

        /// <summary>
        /// Metodas, naudojamas kai gaunamas message į ws://{ip_address}/Connection route.
        /// Metode išanalizuojami gauti duomenys ir jei prisijungusių vartotojų sk. = 2, sukuriamas
        /// žaidimų kambarys ir vartotojas nukeliamas į kambarį.
        /// </summary>
        /// <param name="sender">Siuntėjas</param>
        /// <param name="e">Gauti Duomenys</param>
        static void OnRoomCreate(object sender, MessageEventArgs e)
        {
            if (Convert.ToInt32(e.Data) == 2)
            {
                game = new Game(ip_addr);
                game.setUID(user_id);
                //game.setPlayerPositionAsEnemy();
                game.ShowDialog();
            }
        }

        /// <summary>
        /// Metodas, naudojamas kai gaunamas message į ws://{ip_address}/Positions route.
        /// Metode apdorojami gauti duomenys iš serverio ir patikrinama ar buvo numuštas laivas(ShipHitCheck())
        /// </summary>
        /// <param name="sender">Siuntėjas</param>
        /// <param name="e">Gauti Duomenys</param>
        private static void OnPosMessage(object sender, MessageEventArgs e)
        {
            var items = JsonConvert.DeserializeObject<List<string>>(e.Data);
            var uid = items[1];
            var ship_index = Convert.ToInt32(items[0]);

            if (uid != user_id)
            {
                Debug.WriteLine("Message from the Client!");
                game.ShipHitCheck(ship_index, uid);
            }
        }

        /// <summary>
        /// Metodas, naudojamas kai gaunamas message į ws://{ip_address}/Response
        /// Metode apdorojami gauti duomenys ir pažymimi numušti laivai (UpdateHitShips())
        /// </summary>
        /// <param name="sender">Siuntėjas</param>
        /// <param name="e">Gauti Duomenys</param>
        private static void OnResponseMessage(object sender, MessageEventArgs e)
        {
            var items = JsonConvert.DeserializeObject<List<string>>(e.Data);
            string uid = items[0];
            int ship_index = Convert.ToInt32(items[1]);
            bool hit_status = Convert.ToBoolean(items[2]);

            game.UpdateHitShips(ship_index, uid, hit_status);
        }

        /// <summary>
        /// Metodas, naudojamas kai gaunamas message į ws://{ip_address}/Complete
        /// Metode apdorojami gauti duomenys ir nustatomas žaidimo laimėtojas.
        /// </summary>
        /// <param name="sender">Siuntėjas</param>
        /// <param name="e">Gauti Duomenys</param>
        private static void OnCompleteMessage(object sender, MessageEventArgs e)
        {
            string uid = JsonConvert.DeserializeObject<String>(e.Data);
            game.Completed(uid);
        }


        /// <summary>
        /// Metodas skirtas sugeneruoti UID
        /// </summary>
        /// <returns>Grąžinamas sugeneruotas string</returns>
        public static string GenerateUserID()
        {
            const string chars = "qwertyuiopasdfghjklzxcvbnm,./']ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 12)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
