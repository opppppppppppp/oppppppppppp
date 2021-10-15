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
            this.enemy_field = player_field.Clone() as ShipField;
            enemy_table.DataSource = this.enemy_field.GetTableData();
 
            LevelChecker();
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

        /*private void ScoreChecker()
        {
            if (playerScore >= totalShips)
                complete_socket.Send(user_id);
        }*/
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
            List<string> attackships = GetCorrectStrategy();        
            for(int i = 0;i<attackships.Count;i++)
            {
                int index = GameObject.EnemyPos.GetShipIndex(attackships[i]);
                position_socket.Send($"{index}:{user_id}");
            }
        }

        public List<string> GetCorrectStrategy()
        {
            List<string> attackships = Level.Strategy.GetAttackingShips(GameObject.AttackPos.positions);
            if (GameObject.PlayerPos.DestroyedShips > 2)
            {
                attackships = Level.Strategy.GetAttackingShips(GameObject.AttackPos.positions);
            }
            else
            {
                attackships = Level.IncreasedStrategy.GetAttackingShips(GameObject.AttackPos.positions);
            }
            return attackships;
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
