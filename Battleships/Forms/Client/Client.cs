using Battleships.Models.Observer;
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
    public class Client
    {
        public static Game game { get; set; }
        public static WebSocket ws;
        static string ip_addr;
        //static UserObserver user;
        static string user_id;

        /// <summary>
        /// Metodas, skirtas prisijungti prie ws://{ip_address}/Connection route.
        /// </summary>
        /// <param name="ip_address">IP Address prie kurio jungiames</param>
        public static void Connect(string ip_address)
        {
            //user = new UserObserver(GenerateUserID());
            user_id = GenerateUserID();
            ip_addr = ip_address;
            var wsf = new WebSocketFacade(ip_address, "Connection");
            ws = wsf.Connect(OnRoomCreate, user_id);
        }

        /// <summary>
        /// Metodas, skirtas prisijungti prie ws://{ip_address}/Positions route.
        /// </summary>
        /// <param name="ip_address">Serveris, prie kurio jungiames</param>
        /// <returns>Grąžinamas WebSocket</returns>
        public static WebSocket Positions(string ip_address)
        {
            ip_addr = ip_address;
            var wsf = new WebSocketFacade(ip_address, "Positions");
            ws = wsf.Connect(OnPosMessage);
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
            var wsf = new WebSocketFacade(ip_address, "Response");
            ws = wsf.Connect(OnResponseMessage);
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
            var wsf = new WebSocketFacade(ip_address, "Complete");
            ws = wsf.Connect(OnCompleteMessage);
            return ws;
        }

        public static WebSocket Turn(string ip_address)
        {
            ip_addr = ip_address;
            var wsf = new WebSocketFacade(ip_address, "Turn");
            ws = wsf.Connect(OnTurnMessage);
            return ws;
        }

        static void OnTurnMessage(object sender, MessageEventArgs e)
        {
            string uid = JsonConvert.DeserializeObject<String>(e.Data);
            if (uid == user_id)
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

        /// <summary>
        /// Metodas, naudojamas kai gaunamas message į ws://{ip_address}/Connection route.
        /// Metode išanalizuojami gauti duomenys ir jei prisijungusių vartotojų sk. = 2, sukuriamas
        /// žaidimų kambarys ir vartotojas nukeliamas į kambarį.
        /// </summary>
        /// <param name="sender">Siuntėjas</param>
        /// <param name="e">Gauti Duomenys</param>
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
            if (user_count == 2)
                CreateGame();
            if (user_count == 2 && user_id == uid)
            {
                game.Facade.setUID(user_id);
                game.Facade.SetAttackButtonStatus(true);
                game.Facade.SetSpecialButtonStatus(true);
                game.ShowDialog();
            }
            else if (user_count == 2)
            {
                game.Facade.setUID(user_id);
                game.Facade.SetAttackButtonStatus(false);
                game.Facade.SetSpecialButtonStatus(false);
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
                //Debug.WriteLine("*CLIENT* Message from the Client!");
                game.Facade.ShipHitCheck(ship_index, uid);
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

            game.Facade.UpdateHitShips(ship_index, uid, hit_status);
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
            game.Facade.Completed(uid);
        }

        /// <summary>
        /// Metodas skirtas sugeneruoti UID
        /// </summary>
        /// <returns>Grąžinamas sugeneruotas string</returns>
        public static string GenerateUserID()
        {
            return Guid.NewGuid().ToString();
        }

        public static void CreateGame()
        {
            game = new Game();
        }
    }
}
