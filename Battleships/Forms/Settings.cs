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
        private string path = "config.txt";
        Caretaker caretaker;
        //private 
        public Settings()
        {
            InitializeComponent();

            ApplySelectedValues();
            ApplySettings();
            CheckSettingsFile();
            SetListBoxValues();
            Constants.inited = true;

        }
        private void ApplySelectedValues()
        {
            string imgColor = Constants.caretaker.ShowHistory().Last().GetBackgroundImageName();
            switch (imgColor)
            {
                case "Blue":
                    radioButton1.Checked = true;
                    break;
                case "Red":
                    radioButton2.Checked = true;
                    break;
                case "Green":
                    radioButton3.Checked = true;
                    break;
            }

            switch (Constants.CHAT_COLOR)
            {
                case "white":
                    radioButton4.Checked = true;
                    break;
                case "black":
                    radioButton5.Checked = true;
                    break;

            }
        }
        private void ApplySettings()
        {
            this.BackgroundImage = Image.FromFile(Constants.IMG_DIR);
        }
        private void SetListBoxValues()
        {
            int i = 1;
            foreach (IMemento item in Constants.caretaker.ShowHistory())
            {
                listBox1.Items.Add(i+". "+item.GetBackgroundImageName() + " background - " + item.GetChatColor() + " chat color (" + item.GetDate() + ")");
                i++;
            }

        }

       


        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void CheckSettingsFile()
        {
            using (StreamWriter sw = new StreamWriter(File.Open(path, System.IO.FileMode.Append)))
            {
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var room = new Main();
            room.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            int curIndex = listBox1.Items.IndexOf(text);
            int starting = listBox1.Items.Count-1 - curIndex;
            for (int i = starting; i > 0; i--)
            {
                Constants.caretaker.Undo();
            }
            listBox1.Items.Clear();
            SetListBoxValues();
            Console.WriteLine(curIndex);
            SetVariables();
            ApplySelectedValues();
            ApplySettings();
            UpdateSettingsFile();


        }
        private void SetVariables()
        {
            Constants.IMG_DIR = Constants.caretaker.ShowHistory().Last().GetBackgroundImage();
            Constants.CHAT_COLOR = Constants.caretaker.ShowHistory().Last().GetChatColor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedRadioButtonImg = groupBox1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked).Name;
            string selectedRadioButtonChat = groupBox2.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked).Name;
            string selectedImg = "";
            string chatColor = "";
            string selectedImgUrl = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            
            switch (selectedRadioButtonImg)
            {
                case "radioButton1":
                    selectedImg = "Blue";
                    selectedImgUrl += "/Images/Settings/battleships.png";
                    break;
                case "radioButton2":
                    selectedImg = "Red";
                    selectedImgUrl += "/Images/Settings/battleships_r.png";
                    break;
                case "radioButton3":
                    selectedImg = "Green";
                    selectedImgUrl += "/Images/Settings/battleships_g.png";
                    break;
            }

            switch (selectedRadioButtonChat)
            {
                case "radioButton4":
                    chatColor = "white";
                    break;
                case "radioButton5":
                    chatColor = "black";
                    break;
            }

            Constants.caretaker.SetOriginator(new Originator(selectedImgUrl, selectedImg, chatColor, DateTime.Now.ToString("yyyy-M-d")));
            Constants.caretaker.Backup();
            SetVariables();
            ApplySelectedValues();
            ApplySettings();
            listBox1.Items.Clear();
            SetListBoxValues();
            UpdateSettingsFile();
        }
        private void UpdateSettingsFile()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (StreamWriter w = File.AppendText(path))
            {

                foreach (IMemento item in Constants.caretaker.ShowHistory())
                {
                    string selectedImg = "";
                    string chatColor = "";
                    if (item.GetBackgroundImageName() == "Blue")
                        selectedImg = "b_";
                    if (item.GetBackgroundImageName() == "Red")
                        selectedImg = "r_";
                    if (item.GetBackgroundImageName() == "Green")
                        selectedImg = "g_";

                    if (item.GetChatColor() == "white")
                        chatColor = "0";
                    if (item.GetChatColor() == "black")
                        chatColor = "1";

                    w.WriteLine("bg:"+selectedImg+";cc:"+chatColor+";d:"+item.GetDate());
                }
                w.Close();
            }
        }
    }
}
