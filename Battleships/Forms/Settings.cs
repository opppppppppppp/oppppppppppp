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
        private 
        Originator originator;
        //private 
        public Settings()
        {
            InitializeComponent();
            CheckSettingsFile();
            PassContentToMemento();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ReadContent()
        {
            string[] lines = File.ReadAllLines(path);
        }

        private void CheckSettingsFile()
        {
            using (StreamWriter sw = new StreamWriter(File.Open(path, System.IO.FileMode.Append)))
            {
            }

        }
    }
}
