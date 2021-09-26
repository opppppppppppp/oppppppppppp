using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public class Connection : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                MessageBox.Show(e.Data);
                Send(e.Data);
            }
        }
        public static void InitializeServer(string ip_address)
        {
            try
            {
                WebSocketServer wssv = new WebSocketServer("ws://" + ip_address);
                wssv.Start();
                wssv.AddWebSocketService<Connection>("/Connection");
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

