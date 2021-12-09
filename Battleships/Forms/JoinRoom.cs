using Battleships.Models.Composite;
using Battleships.Models.Template_Method;
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
            ReformButtons();
            ip_address_textbox.Text = Constants.ip_address;
        }

        private void login_server_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ServerConnector con = new ServerConnector();
            con.Connect(Constants.ip_address);
            //Client.Connect(Constants.ip_address);
        }

        private void ReformButtons()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.BackgroundImage = Image.FromFile(ButtonReformer.RandomSubfolderPath());
            }
        }

        private void go_back_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }
    }
}
