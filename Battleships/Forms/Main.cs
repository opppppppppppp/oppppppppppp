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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private static void ShowExceptionDetails(Exception exception)
        {
            MessageBox.Show(exception.Message, exception.TargetSite.ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void create_room_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var room = new Room();
            room.Closed += (s, args) => this.Close();
            room.Show();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void join_room_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var room = new JoinRoom();
            room.Closed += (s, args) => this.Close();
            room.Show();
        }
    }
}
