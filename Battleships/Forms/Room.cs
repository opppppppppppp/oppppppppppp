using Battleships.Models.Composite;
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
    public partial class Room : Form
    {

        public Room()
        {
            InitializeComponent();
            ApplySettings();
            ip_address_textbox.Text = Constants.ip_address;
            ip_address_textbox.ReadOnly = true;
            ReformButtons();

        }
        private void ApplySettings()
        {
            this.BackgroundImage = Image.FromFile(Constants.IMG_DIR);
        }
        private void create_server_btn_Click(object sender, EventArgs e)
        {
            
            Server.InitializeServer();
            this.Hide();
            var waitroom = new WaitRoom();
            waitroom.Show();
        }

        private void ReformButtons()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.BackgroundImage = Image.FromFile(ButtonReformer.RandomFolderPath());
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