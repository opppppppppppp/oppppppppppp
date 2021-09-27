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
        public static void Connect(string ip_address)
        {

            ws = new WebSocket($"ws://{ip_address}/Connection");
            ws.OnMessage += OnMessage;
            ws.Connect();
            ws.Send("Connected");
            game = new Game(ws);
        }

        private static void OnMessage(object sender, MessageEventArgs e)
        {
            if(Convert.ToInt32(e.Data) == 2)
            {
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
