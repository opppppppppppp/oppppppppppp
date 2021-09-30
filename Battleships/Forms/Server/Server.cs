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
    class Server
    {
        public static int connectedUsers = 0;
        static WebSocketServer wssv = new WebSocketServer();

        /// <summary>
        /// Connection Klasė, paveldinti WebSocketBehavior
        /// Šioje klasėje vykdomi metodai, priklausantis ws://{ip_address}/Connection
        /// </summary>
        public class Connection : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                connectedUsers++;
                Sessions.Broadcast(JsonConvert.SerializeObject(connectedUsers));
                Debug.WriteLine($"User Connected (Total Users: {connectedUsers})");
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
                Debug.WriteLine($"Position hit {data[0]} (User ID = {data[1]})");
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
        public class Complete : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                string uid = JsonConvert.SerializeObject(e.Data);
                Sessions.Broadcast(uid);
                Debug.WriteLine($"Winner of the game: {uid}");
            }
        }
        /// <summary>
        /// Metodas skirtas sukurti serverį su tam tikrais Route.
        /// Šiame metode apibrežiami serveryje esantys route, su jiem priklausančia logika.
        /// </summary>
        public static void InitializeServer(string ip_address)
        {
            connectedUsers = 0;
            try
            {
                wssv = ServerInstance.GetInstance();

                wssv.Start();
                wssv.AddWebSocketService<Connection>("/Connection");
                wssv.AddWebSocketService<Positions>("/Positions");
                wssv.AddWebSocketService<Response>("/Response");
                wssv.AddWebSocketService<Complete>("/Complete");
            }
            catch (Exception exception)
            {
                ShowExceptionDetails(exception);
            }
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
    }
}

