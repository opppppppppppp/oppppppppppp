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
    public partial class Room : Form
    {

        public Room()
        {
            InitializeComponent();
        }

        private void create_server_btn_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            Server.InitializeServer(ip_address_textbox.Text);
            this.Hide();
            var waitroom = new WaitRoom(ip_address_textbox.Text);
            waitroom.Show();
        }

        private void go_back_btn_Click(object sender, EventArgs e)
        {
        }

    }
}