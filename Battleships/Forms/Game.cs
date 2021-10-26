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
using Battleships.Models.Bridge;
using Battleships.Models.Adapter;
using Battleships.Models.Command;
using Battleships.Models.Observer;

namespace Battleships
{
    public partial class Game : Form
    {

        public ShipField PlayerPos { get; set; }
        public ShipField EnemyPos { get; set; }
        public ShipField AttackPos { get; set; }
        public List<int> SelectedPlayerPos { get; set; }
        public ShipFactory Ships { get; set; }

        public int playerScore = 0;
        public int currentLevel = 1;
        public ScoreCalculator scoreCalculator = new ScoreCalculator();

        //********************************************************

        Level Level;
        WebSocket position_socket;
        WebSocket response_socket;
        WebSocket complete_socket;


        static string user_id;
        Sailor sailor;

        //*********************************************************

        
        public Game()
        {
            InitializeComponent();
            InitializeGameLogic();
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

        private void InitializeGameLogic()
        {
            LevelChecker();

            PlayerPos = new ShipField(5, player_table, new ShipFieldUpgradeGood());
            EnemyPos = new ShipField(5, enemy_table, new ShipFieldUpgradeEvil());
            AttackPos = new ShipField(5, enemy_table, new ShipFieldUpgradeEvil());
            Ships = Level.ShipFactory;
            SelectedPlayerPos = new Pos().generatePos(0, Ships, PlayerPos);

            enemy_table.DataSource = EnemyPos.GetTableData();
            AddAttackOptions(PlayerPos.GetPositions());
            UpdateScore();

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
            SetText(scoreCalculator.score.ToString());
            //score_val.Text = scoreCalculator.score.ToString();
            ScoreChecker();
        }


        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.score_val.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.score_val.Text = text;
            }
        }

        private void ScoreChecker()
        {
            if (scoreCalculator.score >= Level.NumberOfShips)
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
            //string attackOption = FindShipByIndex(PlayerPos, ship_index);
            string attackOption = PlayerPos.GetShipValue(ship_index);
            if (attackOption == "S")
            {
                MarkLocalShip(ship_index, true);
                response_socket.Send($"{uid}:{ship_index}:{true}");
            }
            else
            {
                MarkLocalShip(ship_index, false);
                response_socket.Send($"{uid}:{ship_index}:{false}");
            }       
        }
        public void UpdateHitShips(int ship_index, string uid, bool hit_status)
        {
            if (sailor.UID != uid)//Nuo cia*
            {
                //Button attackedShip = FindShipByIndex(PlayerPos, ship_index);
                string attackOption = PlayerPos.GetShipValue(ship_index);
                //MarkShip(attackedShip, hit_status);
                MarkLocalShip(ship_index, hit_status);
            }
            else //Iki cia
            if (sailor.UID == uid)
            {
                //Button attackedShip = FindShipByIndex(EnemyPos, ship_index);
                string attackOption = EnemyPos.GetShipValue(ship_index);
                //MarkShip(attackedShip, hit_status);
                MarkEnemyShip(ship_index, hit_status);
                //RemoveShipFromAttackTable(attackedShip);
            }
        }

        public void SpecialAttack()
        {
            List<string> attackships = GetCorrectStrategy();        
            for(int i = 0;i<attackships.Count;i++)
            {
                int index = EnemyPos.GetShipIndex(attackships[i]);
                position_socket.Send($"{index}:{user_id}");
            }
        }

        public List<string> GetCorrectStrategy()
        {
            List<string> attackships = Level.Strategy.GetAttackingShips(AttackPos.positions);
            if (PlayerPos.DestroyedShips >= 2)
            {
                attackships = Level.IncreasedStrategy.GetAttackingShips(AttackPos.positions);
            }
            else
            {
                attackships = Level.Strategy.GetAttackingShips(AttackPos.positions);
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



        public void MarkSelectedShips(ShipField Pos, List<int> selectedPos)
        {
            for (int i = 0; i < selectedPos.Count; i++)
            {
                int index = selectedPos[i];
                Pos.MarkShip(index);
            }
        }
        public void MarkLocalShip(int ship_index, bool hit_status)
        {
            if (hit_status)
            {
                PlayerPos.MarkDestroyedShip(ship_index);
                //MessageBox.Show("You've hit enemy ship!");

                //playerScore++;
                //IncreaseScore();
                UpdateScore();
                //ScoreChecker();
            }
            else
            {
                PlayerPos.MarkHitShip(ship_index);
            }
        }
        public void MarkEnemyShip(int ship_index, bool hit_status)
        {
            if (hit_status)
            {
                EnemyPos.MarkDestroyedShip(ship_index);
                //MessageBox.Show("You've hit enemy ship!");
                //playerScore++;
                IncreaseScore();
                UpdateScore();
                //ScoreChecker();
            }
            else
            {
                EnemyPos.MarkHitShip(ship_index);
            }
        }
        public void RestartGame()
        {
            AttackPos = EnemyPos;
            playerScore = 0;
            SelectedPlayerPos = new Pos().generatePos(0, Ships, PlayerPos);
            MarkSelectedShips(PlayerPos, SelectedPlayerPos);
        }
        public void IncreaseScore()
        {
            scoreCalculator.ExecuteCommand(new AddScoreCommand(1));
        }

        delegate void SetBtnStatus(bool status);
        private void SetButtonStatus(bool status)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.attack_btn.InvokeRequired)
            {
                SetBtnStatus d = new SetBtnStatus(SetButtonStatus);
                this.Invoke(d, new object[] { status });
            }
            else
            {
                this.attack_btn.Enabled = status;
            }
        }
        public void ButtonStatusChange()
        {
            if (attack_btn.Enabled)
                SetButtonStatus(false);
            else
                SetButtonStatus(true);
        }
    }
}
