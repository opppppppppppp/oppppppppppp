using Battleships.Models.Interpreter;
using Battleships.Models.Memento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships.Forms
{
    public partial class Settings : Form
    {
        private string path = "Settings/config.txt";
        Caretaker caretaker;
        //private 
        public Settings()
        {
            InitializeComponent();
            CheckSettingsFile();
            PassContentToMemento();
            SetListBoxValues();
           
        }

        private void SetListBoxValues()
        {
            foreach (IMemento item in caretaker.ShowHistory())
            {
                listBox1.Items.Add(item.GetBackgroundImageName()+" background - "+item.GetChatColor()+" chat color ("+item.GetDate()+")");
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PassContentToMemento()
        {
            string[] lines = File.ReadAllLines(path);
            Context context = new Context(lines[0]);
            Originator originator = new Originator(context.GetBackgroundColor(), context.GetBackgroundName(), context.GetChatColor(), context.GetDate());
            caretaker = new Caretaker(originator);
            caretaker.Backup();
            for (int i = 1; i < lines.Length; i++)
            {
                
                context = new Context(lines[i]);
                originator.SetSettings(context.GetBackgroundColor(), context.GetBackgroundName(), context.GetChatColor(), context.GetDate());
                caretaker.Backup();
            }
        }

        private void CheckSettingsFile()
        {
            using (StreamWriter sw = new StreamWriter(File.Open(path, System.IO.FileMode.Append)))
            {
            }

        }
    }
}
