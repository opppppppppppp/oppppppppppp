using Battleships.Models;
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
        private ShipField field;
        public Main()
        {
            InitializeComponent();
            this.field = new ShipField(3, table);
           
            //table = field.MarkShip(5);
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

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = field.GetRowAndColumn(5)[0];
            int column = field.GetRowAndColumn(5)[1];
            table.Rows[row].Cells[column].Style.BackColor = Color.Red;
        }
    }
}
