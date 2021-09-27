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

namespace Battleships.Forms
{
    public partial class WaitRoom : Form
    {
        public WaitRoom(string ip_address)
        {
            InitializeComponent();
            server_ip_address.Text = ip_address;
            Client.Connect(ip_address);

        }


        private void WaitRoom_Load(object sender, EventArgs e)
        {

        }

        private void server_ip_address_Click(object sender, EventArgs e)
        {

        }
    }
}
