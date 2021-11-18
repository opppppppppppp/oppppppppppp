using Battleships.Models.Observer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WebSocketSharp;
using WebSocketSharp.Server;

namespace Battleships.Forms
{
    public class Server
    {
        public static int connectedUsers = 0;
        static TurnSubject playerTurn = new TurnSubject();
        private static ServerInstance serverInstance = ServerInstance.Instance;
        static WebSocketServer webSocketServer = serverInstance.GetWebSocketServer();
        // = new WebSocketServer();

        /// <summary>
        /// Connection Klasė, paveldinti WebSocketBehavior
        /// Šioje klasėje vykdomi metodai, priklausantis ws://{ip_address}/Connection
        /// </summary>
        public class Connection : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                string user_id = e.Data;
                playerTurn.Register(new UserObserver(user_id));
                connectedUsers++;
                Sessions.Broadcast($"{user_id}:{connectedUsers}");
            
                Debug.WriteLine($"*SERVER* User ({user_id}) Connected (Total Users: {connectedUsers})");
            }
        }


        /// <summary>
        /// Positions Klasė, paveldinti WebSocketBehavior
        /// Šioje klasėje vykdomi metodai, priklausantis ws://{ip_address}/Positions
        /// </summary>
        public class Positions : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                string[] data = e.Data.Split(':');
                Sessions.Broadcast(JsonConvert.SerializeObject(data));
                Debug.WriteLine($"*SERVER* Position hit {data[0]} (User ID = {data[1]})");
            }
        }
        /// <summary>
        /// Response Klasė, paveldinti WebSocketBehavior
        /// Šioje klasėje vykdomi metodai, priklausantis ws://{ip_address}/Response
        /// </summary>
        public class Response : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                string[] data = e.Data.Split(':');
                Sessions.Broadcast(JsonConvert.SerializeObject(data));
                Debug.WriteLine($"Response: {e.Data}");
            }
        }

        /// <summary>
        /// Complete Klasė, paveldinti WebSocketBehavior
        /// Šioje klasėje vykdomi metodai, priklausantis ws://{ip_address}/Complete
        /// </summary>
        public class Turn : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                string uid = JsonConvert.SerializeObject(e.Data);
                playerTurn.Notify(uid, Sessions);
                Debug.WriteLine($"*SERVER* User turn id: {uid}");
            }
        }

        public class Complete : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                string uid = JsonConvert.SerializeObject(e.Data);
                Sessions.Broadcast(uid);
                Debug.WriteLine($"*SERVER* Winner of the game: {uid}");
            }
        }

        /// <summary>
        /// Metodas skirtas sukurti serverį su tam tikrais Route.
        /// Šiame metode apibrežiami serveryje esantys route, su jiem priklausančia logika.
        /// </summary>
        public static bool InitializeServer()
        {
            connectedUsers = 0;
            try
            {
                webSocketServer.Start();
                webSocketServer.AddWebSocketService<Connection>("/Connection");
                webSocketServer.AddWebSocketService<Positions>("/Positions");
                webSocketServer.AddWebSocketService<Response>("/Response");
                webSocketServer.AddWebSocketService<Complete>("/Complete");
                webSocketServer.AddWebSocketService<Turn>("/Turn");
                return true;
            }
            catch (Exception exception)
            {
                ShowExceptionDetails(exception);
            }
            return false;
        }
        /// <summary>
        /// Exception metodas, grąžinantis klaidas.
        /// </summary>
        /// <param name="exception">Klaida</param>
        private static void ShowExceptionDetails(Exception exception)
        {
            MessageBox.Show(exception.Message, exception.TargetSite.ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool InitializeServer(object ip_address)
        {
            throw new NotImplementedException();
        }
    }
}

