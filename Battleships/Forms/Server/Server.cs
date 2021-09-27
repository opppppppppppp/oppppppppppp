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
        public static int user_id = 0;
        static WebSocketServer wssv = new WebSocketServer();
        public class Connection : WebSocketBehavior
        {         
            protected override void OnMessage(MessageEventArgs e)
            {
                connectedUsers++;
                Sessions.Broadcast(JsonConvert.SerializeObject(connectedUsers));
                Debug.WriteLine("Users Connected: " + connectedUsers);
            }

        }  
    

        public class Positions : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                string[] data = e.Data.Split(':');
                Sessions.Broadcast(JsonConvert.SerializeObject(data));
                Debug.WriteLine("Position hiited: " + data[0] +" --- "+ data[1]);
            }
        }  
        public class Response : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                Debug.WriteLine("Response: " + e.Data);
            }
        }


        public static void InitializeServer(string ip_address)
        {
            connectedUsers = 0;
            try
            {
                wssv = new WebSocketServer($"ws://{ip_address}");
                
                wssv.Start();
                wssv.AddWebSocketService<Connection>("/Connection");
                wssv.AddWebSocketService<Positions>("/Positions");
                wssv.AddWebSocketService<Response>("/Response");
            }
            catch (Exception exception)
            {
                ShowExceptionDetails(exception);
            }
        }

        

        private static void ShowExceptionDetails(Exception exception)
        {
            MessageBox.Show(exception.Message, exception.TargetSite.ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

