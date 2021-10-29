using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Battleships.Forms;
using Battleships.LevelBuilder;
using Battleships.Models.Adapter;
using Battleships.Models.Bridge;
using Battleships.Models.Command;
using WebSocketSharp;

namespace Battleships.Models.Facade
{
    public class Facade
    {
        private Game Game;
        private GameObjects GameObjects;

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
        public WebSocket position_socket;
        WebSocket response_socket;
        WebSocket complete_socket;
        public WebSocket player_turn;


        public static string user_id;
        Sailor sailor;

        //*********************************************************

        public Facade(Game Game, GameObjects GameObjects)
        {
            position_socket = Client.Positions(Constants.ip_address);
            response_socket = Client.Response(Constants.ip_address);
            complete_socket = Client.Complete(Constants.ip_address);
            player_turn = Client.Turn(Constants.ip_address);
            this.Game = Game;
            this.GameObjects = GameObjects;
        }

        public List<string> GetCorrectStrategy(Level Level, ShipField AttackPos, ShipField PlayerPos)
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

        public void InitializeGameLogic()
        {
            LevelChecker();
            Ships = Level.ShipFactory;
            PlayerPos = new ShipField(6, GameObjects.player_table, new ShipFieldUpgradeGood(), Ships);
            EnemyPos = new ShipField(6, GameObjects.enemy_table, new ShipFieldUpgradeEvil(), Ships);
            AttackPos = EnemyPos.DeepClone();
            SelectedPlayerPos = new Pos().generatePos(0, Level, PlayerPos);
            GameObjects.enemy_table.DataSource = EnemyPos.GetTableData();
            AddAttackOptions(AttackPos.GetPositions());
            UpdateScore();

            /*Debug.WriteLine("Memory Address of EnemyPos : " + AddressHelper.GetAddress(EnemyPos));
            Debug.WriteLine("Memory Address of EnemyPos.positions : " + AddressHelper.GetAddress(EnemyPos.positions));
            Debug.WriteLine("Memory Address of Cloned EnemyPos : " + AddressHelper.GetAddress(AttackPos));
            Debug.WriteLine("Memory Address of Cloned EnemyPos.positions : " + AddressHelper.GetAddress(AttackPos.positions));*/
        }


        /*public void PrintMemoryAddress(ShipField obj, ShipField objCloned)
        {
            Debug.WriteLine("Memory Address of EnemyPos : " + GetMemoryAddress(obj));
            Debug.WriteLine("Memory Address of EnemyPos.ships : " + GetMemoryAddress(obj.positions));
            Debug.WriteLine("Memory Address of Cloned EnemyPos : " + GetMemoryAddress(objCloned));
            Debug.WriteLine("Memory Address of Cloned EnemyPos.ships : " + GetMemoryAddress(objCloned.positions));
        }*/

        public void setUID(string uid)
        {
            user_id = uid;
            sailor = new Sailor(uid);
        }

        private void AddAttackOptions(List<string> options)
        {
            GameObjects.attack_options.Items.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                GameObjects.attack_options.Items.Add(options[i]);
            }
        }
        private void LevelChecker()
        {
            switch (currentLevel)
            {
                case 1:
                    InitLevel(new LevelOneBuilder());
                    break;
                case 2:
                    InitLevel(new LevelTwoBuilder());
                    break;
                case 3:
                    InitLevel(new LevelThreeBuilder());
                    break;
            }
        }

        private void InitLevel(ILevelBuilder levelBuilder)
        {
            LevelCreator LevelCreator = new LevelCreator(levelBuilder);
            LevelCreator.CreateLevel();
            Level = LevelCreator.GetLevel();
            GameObjects.special_ability_label.Text = Level.Strategy.Name;
        }

        private void UpdateScore()
        {
            SetText(scoreCalculator.score.ToString());
            //score_val.Text = scoreCalculator.score.ToString();
            ScoreChecker();
        }

        private void ScoreChecker()
        {
            if (scoreCalculator.score >= Level.NumberOfShips)
                complete_socket.Send(user_id);
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
            List<string> attackships = GetCorrectStrategy(Level, AttackPos, PlayerPos);
            for (int i = 0; i < attackships.Count; i++)
            {
                int index = EnemyPos.GetShipIndex(attackships[i]);
                position_socket.Send($"{index}:{user_id}");
            }
            player_turn.Send($"{user_id}");
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
            AttackPos = EnemyPos.Clone() as ShipField;
            playerScore = 0;
            SelectedPlayerPos = new Pos().generatePos(0, Level, PlayerPos);
            MarkSelectedShips(PlayerPos, SelectedPlayerPos);
        }
        public void IncreaseScore()
        {
            scoreCalculator.ExecuteCommand(new AddScoreCommand(1));
        }

        delegate void SetAttackBtnStatus(bool status);
        public void SetAttackButtonStatus(bool status)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (GameObjects.attack_btn.InvokeRequired)
            {
                SetAttackBtnStatus d = new SetAttackBtnStatus(SetAttackButtonStatus);
                Game.Invoke(d, new object[] { status });
            }
            else
            {
                GameObjects.attack_btn.Enabled = status;
            }
        }

        delegate void SetSpecialBtnStatus(bool status);
        public void SetSpecialButtonStatus(bool status)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (GameObjects.attack_btn.InvokeRequired)
            {
                SetSpecialBtnStatus d = new SetSpecialBtnStatus(SetSpecialButtonStatus);
                Game.Invoke(d, new object[] { status });
            }
            else
            {
                GameObjects.special_ability_btn.Enabled = status;
            }
        }

        delegate void SetTextCallback(string text);

        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (GameObjects.score_val.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Game.Invoke(d, new object[] { text });
            }
            else
            {
                GameObjects.score_val.Text = text;
            }
        }
    }
}
