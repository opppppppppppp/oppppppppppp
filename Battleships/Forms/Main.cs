using Battleships.Models;
using Battleships.Models.Composite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private ShipField field;
        public Main()
        {
            InitializeComponent();
            ReformButtons();
        }

        private void ReformButtons()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.BackgroundImage = Image.FromFile(ButtonReformer.RandomFolderPath());
            }
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
            room.Show();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void join_room_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var joinroom = new JoinRoom();
            joinroom.Show();
        }

        private void table_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
