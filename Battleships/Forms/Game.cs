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
using Battleships.Models;
using Battleships.Models.ConcreteCreator;
using Battleships.Models.Strategy;

namespace Battleships
{
    public partial class Game : Form
    {
        List<Button> playerPos;
        List<Button> enemyPos;
        List<Button> attackPos;
        List<int> selectedPlayerPos;

        ShipFactory ships;
        IAttackStrategy attackstrategy;

        WebSocket position_socket;
        WebSocket response_socket;
        WebSocket complete_socket;

        int totalShips = 4;
        int playerScore = 0;
        int currentLevel = 2;
        static string user_id;
        Sailor sailor;
        public Game()
        {
            InitializeComponent();
            position_socket = Client.Positions(Constants.ip_address);
            response_socket = Client.Response(Constants.ip_address);
            complete_socket = Client.Complete(Constants.ip_address);
            RestartGame();
        }
        public void setUID(string uid)
        {
            user_id = uid;
            sailor = new Sailor(uid);
        }
        private List<int> generateRandomPos()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<int> positions = new List<int>();
            while (positions.Count != ships.GetShip().ShipSize)
            {
                int number = rnd.Next(1, 24);
                if (!positions.Contains(number))
                {
                    positions.Add(number);
                }
            }
            return positions;
        }

        private int getEnemyShipIndex(Button ship)
        {
            return enemyPos.IndexOf(ship);
        }

        private void markShipColor(List<Button> Pos, List<int> selectedPos)
        {
            for (int i = 0; i < selectedPos.Count; i++)
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
            for (int i = 0; i < options.Count; i++)
            {
                attack_options.Items.Add(options[i].Text);
            }

        }

        private void RemoveShipFromAttackTable(Button Ship)
        {
            attackPos.Remove(Ship);
        }
        private void RemoveAttackOption(string option)
        {
            attack_options.Items.Remove(option);
            //options.Remove(option);
        }

        private void MarkShip(Button Ship, bool hit_status)
        {
            Ship.Invoke((MethodInvoker)(() =>
            {
                if (hit_status)
                {
                    Ship.BackColor = Color.Red;
                    Ship.Text = "X";
                    MessageBox.Show("You've hit enemy ship!");
                    playerScore++;
                    UpdateScore();
                    ScoreChecker();

                }
                else
                {
                    Ship.BackColor = Color.Red;
                }
            }));
        }
        private void LevelChecker()
        {
            switch(currentLevel)
            {
                case 1:
                    ships = new ShipSmallFactory(4);
                    attackstrategy = new BombAttackStrategy();
                    special_ability_label.Text = attackstrategy.Name;
                    break;
                case 2:
                    ships = new ShipMediumFactory(5);
                    attackstrategy = new DynamiteAttackStrategy();
                    special_ability_label.Text = attackstrategy.Name;
                    break;
                case 3:
                    ships = new ShipBigFactory(6);
                    attackstrategy = new MissileAttackStrategy();
                    special_ability_label.Text = attackstrategy.Name;
                    break;
            }
        }
        private Button FindShipByIndex(List<Button> positions, int index)
        {
            return positions[index];
        }

        private void UpdateScore()
        {
            score_val.Text = playerScore.ToString();
        }

        private void ScoreChecker()
        {
            if (playerScore >= totalShips)
                complete_socket.Send(user_id);
        }

        public void RestartGame()
        {
            LevelChecker();
            playerPos = new List<Button> { w1, w2, w3, w4, w5, x1, x2, x3, x4, x5, y1, y2, y3, y4, y5, z1, z2, z3, z4, z5, f1, f2, f3, f4, f5 };
            enemyPos = new List<Button> { a1, a2, a3, a4, a5, b1, b2, b3, b4, b5, c1, c2, c3, c4, c5, d1, d2, d3, d4, d5, e1, e2, e3, e4, e5 };
            attackPos = enemyPos;

            for (int i = 0; i < playerPos.Count; i++)
            {
                playerPos[i].BackColor = Color.White;
                enemyPos[i].BackColor = Color.White;

                playerPos[i].Tag = null;
                enemyPos[i].Tag = null;
            }
            playerScore = 0;
            level_value.Text = currentLevel.ToString();

            selectedPlayerPos = generateRandomPos();

            markShipColor(playerPos, selectedPlayerPos);
            markShipTag(playerPos, selectedPlayerPos);
            AddAttackOptions(attackPos);
            UpdateScore();

        }

        private void attack_btn_Click(object sender, EventArgs e)
        {
            int index = attack_options.SelectedIndex;
            //RemoveAttackOption(FindShipByIndex(enemyPos, index).Text);//*Cia*
            position_socket.Send($"{index}:{user_id}");
        }
        public void ShipHitCheck(int ship_index, string uid)
        {
            Button attackOption = FindShipByIndex(playerPos, ship_index);
            if (attackOption.Tag == "Ship")
            {
                MarkShip(attackOption, false);
                response_socket.Send($"{uid}:{ship_index}:{true}");
            }
            else
                response_socket.Send($"{uid}:{ship_index}:{false}");
        }

        public void UpdateHitShips(int ship_index, string uid, bool hit_status)
        {
            if (sailor.UID != uid)//Nuo cia*
            {
                Button attackedShip = FindShipByIndex(playerPos, ship_index);
                MarkShip(attackedShip, hit_status);           
            }
            else //Iki cia
            if (sailor.UID == uid)
            {
                Button attackedShip = FindShipByIndex(enemyPos, ship_index);
                MarkShip(attackedShip, hit_status);
                RemoveShipFromAttackTable(attackedShip);
            }
        }

        public void SpecialAttack()
        {
            List<Button> attackships = attackstrategy.GetAttackingShips(attackPos);
            for(int i = 0;i<attackships.Count;i++)
            {
                int index = enemyPos.IndexOf(attackships[i]);
                position_socket.Send($"{index}:{user_id}");
            }
        }

        public void Completed(string uid)
        {
            if (sailor.UID == uid)
            {
                position_socket.Close();
                response_socket.Close();
                complete_socket.Close();
                MessageBox.Show("You are the winner");
                Application.Exit();
            }
            else
            {
                position_socket.Close();
                response_socket.Close();
                complete_socket.Close();
                MessageBox.Show("You've lost the game!");
                Application.Exit();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void special_ability_btn_Click(object sender, EventArgs e)
        {
            SpecialAttack();
            special_ability_btn.Hide();
            special_ability_label.Hide();
           
        }
    }
}
