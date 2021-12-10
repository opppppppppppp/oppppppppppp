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

namespace Battleships.Forms
{
   


    public partial class JoinRoom : Form
    {
        public JoinRoom()
        {
            InitializeComponent();
            ip_address_textbox.Text = Constants.ip_address;
        }

        private void login_server_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client.Connect(Constants.ip_address);
        }

        private void go_back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }
    }
}
