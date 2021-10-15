using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WebSocketSharp;
using Battleships.Forms;
using Battleships.Models;
using Battleships.Models.ConcreteCreator;
using Battleships.Models.Strategy;
using Battleships.LevelBuilder;

namespace Battleships
{
    public partial class Game : Form
    {
        private GameLogic GameObject;
        private ShipField player_field;
        private ShipField enemy_field;

        Level Level;
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
            InitializeGameLogic();
            position_socket = Client.Positions(Constants.ip_address);
            response_socket = Client.Response(Constants.ip_address);
            complete_socket = Client.Complete(Constants.ip_address);
            GameObject.RestartGame();
        }
        public void setUID(string uid)
        {
            user_id = uid;
            sailor = new Sailor(uid);
        }

        private void InitializeGameLogic()
        {
            this.player_field = new ShipField(5, player_table);
            this.enemy_field = new ShipField(5, enemy_table);
            //var PlayerPos = new List<Button> { w1, w2, w3, w4, w5, x1, x2, x3, x4, x5, y1, y2, y3, y4, y5, z1, z2, z3, z4, z5, f1, f2, f3, f4, f5 };
            //var EnemyPos = new List<Button> { a1, a2, a3, a4, a5, b1, b2, b3, b4, b5, c1, c2, c3, c4, c5, d1, d2, d3, d4, d5, e1, e2, e3, e4, e5 };
            LevelChecker();
            //GameObject = new GameLogic(PlayerPos, EnemyPos, Level.ShipFactory);
            GameObject = new GameLogic(player_field, enemy_field, Level.ShipFactory);
            AddAttackOptions(player_field.GetPositions());
            UpdateScore();
            LevelChecker();
        }

        private void AddAttackOptions(List<string> options)
        {
            attack_options.Items.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                attack_options.Items.Add(options[i]);
            }
        }

        private void RemoveAttackOption(string option)
        {
            attack_options.Items.Remove(option);
            //options.Remove(option);
        }
        private void LevelChecker()
        {
            switch (currentLevel)
            {        
                case 1:
                    this.InitLevel(new LevelOneBuilder());
                    break;
                case 2:
                    this.InitLevel(new LevelTwoBuilder());
                    break;
                case 3:
                    this.InitLevel(new LevelThreeBuilder());
                    break;
            }
        }

        private void InitLevel(ILevelBuilder levelBuilder)
        {
            LevelCreator  LevelCreator = new LevelCreator(levelBuilder);
            LevelCreator.CreateLevel();
            Level = LevelCreator.GetLevel();
            special_ability_label.Text = Level.Strategy.Name;
        }

        private void UpdateScore()
        {
            score_val.Text = GameObject.Score.ToString();
        }

        private void ScoreChecker()
        {
            if (playerScore >= totalShips)
                complete_socket.Send(user_id);
        }
        private void Attack_btn_Click(object sender, EventArgs e)
        {
            int index = attack_options.SelectedIndex;
            //RemoveAttackOption(FindShipByIndex(enemyPos, index).Text);//*Cia*
            position_socket.Send($"{index}:{user_id}");
        }
        public void ShipHitCheck(int ship_index, string uid)
        {
            //string attackOption = GameObject.FindShipByIndex(GameObject.PlayerPos, ship_index);
            string attackOption = GameObject.PlayerPos.GetShipValue(ship_index);
            if (attackOption == "S")
            {
                GameObject.MarkLocalShip(ship_index, true);
                response_socket.Send($"{uid}:{ship_index}:{true}");
            }
            else
            {
                GameObject.MarkLocalShip(ship_index, false);
                response_socket.Send($"{uid}:{ship_index}:{false}");
            }
                
        }

        public void UpdateHitShips(int ship_index, string uid, bool hit_status)
        {
            if (sailor.UID != uid)//Nuo cia*
            {
                //Button attackedShip = GameObject.FindShipByIndex(GameObject.PlayerPos, ship_index);
                string attackOption = GameObject.PlayerPos.GetShipValue(ship_index);
                //GameObject.MarkShip(attackedShip, hit_status);
                GameObject.MarkLocalShip(ship_index, hit_status);
            }
            else //Iki cia
            if (sailor.UID == uid)
            {
                //Button attackedShip = GameObject.FindShipByIndex(GameObject.EnemyPos, ship_index);
                string attackOption = GameObject.EnemyPos.GetShipValue(ship_index);
                //GameObject.MarkShip(attackedShip, hit_status);
                GameObject.MarkEnemyShip(ship_index, hit_status);
                //GameObject.RemoveShipFromAttackTable(attackedShip);
            }
        }

        public void SpecialAttack()
        {
            /*List<Button> attackships = Level.Strategy.GetAttackingShips(GameObject.AttackPos);
            for(int i = 0;i<attackships.Count;i++)
            {
                int index = GameObject.EnemyPos.IndexOf(attackships[i]);
                position_socket.Send($"{index}:{user_id}");
            }*/
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
