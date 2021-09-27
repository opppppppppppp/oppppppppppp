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
using Newtonsoft;
using Newtonsoft.Json;
using Battleships.Forms;
using System.Diagnostics;

namespace Battleships
{
    public partial class Game : Form
    {
        List<Button> playerPos;
        List<Button> enemyPos;
        List<Button> attackPos;
        List<int> selectedPlayerPos;
        List<int> selectedEnemyPos;
        WebSocket client;
        int totalShips = 4;
        int playerScore = 0;
        int enemyScore = 0;
        public Game(WebSocket ws)
        {
            InitializeComponent();
            selectedPlayerPos = generateRandomPos(playerPos);
            selectedEnemyPos = generateRandomPos(enemyPos);
            playerScore = 0;
            enemyScore = 0;
            client = ws;
            RestartGame();
        }

        private void user_b_Click(object sender, EventArgs e)
        {

        }

        private List<int> generateRandomPos(List<Button> pos)
        {
            Random rnd = new Random();
            List<int> positions = new List<int>();
            while(positions.Count != 4)
            {
                int number = rnd.Next(1, 24);
                if(!positions.Contains(number))
                {
                    positions.Add(number);
                }
            }
            return positions;
        }

        private void markShipColor(List<Button> Pos, List<int> selectedPos)
        {
            for(int i = 0;i<selectedPos.Count;i++)
            {
                int index = selectedPos[i];
                Pos[index].BackColor = Color.Green;
            }
        }

        private void markShipTag(List<Button> Pos, List<int> selectedPos)
        {
            for (int i = 0; i < selectedPos.Count; i++)
            {
                int index = selectedPos[i];
                Pos[index].Tag = "Ship";
            }
        }

        private void AddAttackOptions(List<Button> options)
        {
            attack_options.Items.Clear();
            for(int i=0;i<options.Count;i++)
            {
                attack_options.Items.Add(options[i].Text);
            }
        }

        private void RemoveAttackOption(List<Button> options, Button option)
        {
            options.Remove(option);
        }

        private void AttackShip(Button attackShip)
        {
            //Button result = enemyPos.Find(x => x.Text == attackShip.Text);
            if(attackShip.Tag == "Ship")
            {
                attackShip.BackColor = Color.Red;
                attackShip.Text = "X";
                playerScore++;
                MessageBox.Show("You have hit enemy Ship!");
                UpdateScore();
                ScoreChecker();
            }
            else { attackShip.BackColor = Color.Red; }
            RemoveAttackOption(attackPos, attackShip);
        }

        private Button FindShipByIndex(List<Button> enemyPos, int index)
        {
            return enemyPos[index];
        }

        private void UpdateScore()
        {
            score_val.Text = playerScore.ToString();
        }

        private void ScoreChecker()
        {
            if(playerScore == totalShips)
            {
                MessageBox.Show("YOU ARE THE WINNER");
                this.Close();
            }
        }


        public void RestartGame()
        {
            playerPos = new List<Button> { w1, w2, w3, w4, w5, x1, x2, x3, x4, x5, y1, y2, y3, y4,y5, z1, z2, z3, z4,z5, f1, f2, f3, f4, f5 };
            enemyPos = new List<Button> { a1, a2, a3, a4, a5, b1, b2, b3, b4,b5, c1, c2, c3, c4, c5, d1, d2, d3, d4, d5, e1, e2, e3, e4, e5 };
            attackPos = enemyPos;
            //List<String> p = new List<String> { "w1", "w2", "w3" };
            //client.Send("W");
            
            //client.Send(JsonConvert.SerializeObject(p));

            for(int i = 0;i<playerPos.Count;i++)
            {
                playerPos[i].BackColor = Color.White;
                enemyPos[i].BackColor = Color.White;

                playerPos[i].Tag = null;
                enemyPos[i].Tag = null;
            }
            playerScore = 0;
            enemyScore = 0;

            markShipColor(playerPos, selectedPlayerPos);
            markShipTag(playerPos, selectedPlayerPos);
            markShipTag(enemyPos, selectedEnemyPos);
            AddAttackOptions(attackPos);
            UpdateScore();

        }

        private void timer_label_Click(object sender, EventArgs e)
        {

        }

        private void attack_btn_Click(object sender, EventArgs e)
        {
            //Button selected_value = attack_options.SelectedItem;
            int index = attack_options.SelectedIndex;
            Button attackOption = FindShipByIndex(enemyPos, index);

            AttackShip(attackOption);
            AddAttackOptions(enemyPos);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
