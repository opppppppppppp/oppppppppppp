using Battleships.Models;
using Battleships.Models.Composite;
using Battleships.Models.Interpreter;
using Battleships.Models.Memento;
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
        private string path = "config.txt";
        private string defaultValue = "bg:b_;cc:0;d:2021-10-01";
        public Main()
        {
            InitializeComponent();
            ReformButtons();
            if (!Constants.inited)
            {
                PassContentToMemento();
                SetVariables();
            }
            ApplySettings();

        }

       
        private void PassContentToMemento()
        {

            using (StreamWriter w = File.AppendText(path))
            {
                if (new FileInfo(path).Length == 0)
                    w.WriteLine(defaultValue);
                w.Close();
            }

            string[] lines = File.ReadAllLines(path);
            Context context = new Context(lines[0]);
            Originator originator = new Originator(context.GetBackgroundColor(), context.GetBackgroundName(), context.GetChatColor(), context.GetDate());
            Constants.caretaker = new Caretaker(originator);
            Constants.caretaker.Backup();
            for (int i = 1; i < lines.Length; i++)
            {

                context = new Context(lines[i]);
                originator.SetSettings(context.GetBackgroundColor(), context.GetBackgroundName(), context.GetChatColor(), context.GetDate());
                Constants.caretaker.Backup();
            }
        }

        private void SetVariables()
        {
            Constants.IMG_DIR = Constants.caretaker.ShowHistory().Last().GetBackgroundImage();
            Constants.CHAT_COLOR = Constants.caretaker.ShowHistory().Last().GetChatColor();
        }

        private void ApplySettings()
        {
            this.BackgroundImage = Image.FromFile(Constants.IMG_DIR);
        }


        private void ReformButtons()
        {
            foreach (var button in this.Controls.OfType<Button>())
            {
                button.FlatAppearance.BorderSize = 0;
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var settings = new Settings();
            settings.Show();
        }
    }
}
