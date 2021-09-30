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
            ip_address_textbox.Text = Constants.ip_address;
            ip_address_textbox.ReadOnly = true;
        }

        private void create_server_btn_Click(object sender, EventArgs e)
        {
            Server.InitializeServer(Constants.ip_address);
            this.Hide();
            var waitroom = new WaitRoom();
            waitroom.Show();
        }

        private void go_back_btn_Click(object sender, EventArgs e)
        {
        }

    }
}