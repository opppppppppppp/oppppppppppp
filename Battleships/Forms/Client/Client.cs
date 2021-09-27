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
            try
            {
                ws = new WebSocket($"ws://{ip_address}/Connection");
                game = new Game(ws);
                ws.OnMessage += JoinRoom;
                ws.Connect();
                ws.Send("Connected");
            }
            catch (Exception exception)
            {
                ShowExceptionDetails(exception);
            }
        }

        private static void JoinRoom(object sender, MessageEventArgs e)
        {
            if(Convert.ToInt32(e.Data) == 2)
            {
                try
                {
                    game.ShowDialog();
                }catch(Exception exception)
                {
                    Debug.WriteLine(exception.Message);
                }

            }
        }

        private static void ShowExceptionDetails(Exception exception)
        {
            MessageBox.Show(exception.Message, exception.TargetSite.ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
