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
using Battleships.Models.Template_Method;
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

        public Level Level;
        //public Connections connections;
        public ConnectionAccessor positionsConnector = new PositionsConnector();
        public ConnectionAccessor responseConnector = new ResponseConnector();
        public ConnectionAccessor turnConnector = new TurnConnector();
        public ConnectionAccessor completeConnector = new CompleteConnector();
        public ConnectionAccessor chatConnector = new ChatConnector();
        public Player player;

        //*********************************************************

        public Facade(Game Game, GameObjects GameObjects, Player pl)
        {
            //connections = new Connections();
            //connections.Connect(Constants.ip_address);
            this.Game = Game;
            this.GameObjects = GameObjects;
            this.player = pl;
            positionsConnector.Run(Constants.ip_address, Game, pl);
            responseConnector.Run(Constants.ip_address, Game, pl);
            turnConnector.Run(Constants.ip_address, Game, pl);
            completeConnector.Run(Constants.ip_address, Game, pl);
            chatConnector.Run(Constants.ip_address, Game, pl);
        }

        public List<string> GetCorrectStrategy(Level Level, ShipField AttackPos, ShipField PlayerPos)
        {
            List<string> attackships = Level.Strategy.GetAttackingShips(AttackPos._posObject.positions);
            if (PlayerPos.DestroyedShips >= 2)
            {
                attackships = Level.IncreasedStrategy.GetAttackingShips(AttackPos._posObject.positions);
            }
            else
            {
                attackships = Level.Strategy.GetAttackingShips(AttackPos._posObject.positions);
            }
            return attackships;
        }

        public void InitializeGameLogic()
        {
            LevelChecker();
            Ships = Level.ShipFactory;
            PlayerPos = new ShipField(6, GameObjects.player_table, new ShipFieldUpgradeGood(), Ships);
            EnemyPos = new ShipField(6, GameObjects.enemy_table, new ShipFieldUpgradeEvil(), Ships);
            AttackPos = (ShipField)EnemyPos.DeepClone();
            SelectedPlayerPos = new Pos().generatePos(0, Level, PlayerPos);
            GameObjects.enemy_table.DataSource = EnemyPos.GetTableData();
            AddAttackOptions(AttackPos.GetPositions());
            UpdateScore();

            /*Debug.WriteLine("Memory Address of EnemyPos : " + AddressHelper.GetAddress(EnemyPos));
            Debug.WriteLine("Memory Address of EnemyPos.positions : " + AddressHelper.GetAddress(EnemyPos.positions));
            Debug.WriteLine("Memory Address of Cloned EnemyPos : " + AddressHelper.GetAddress(AttackPos));
            Debug.WriteLine("Memory Address of Cloned EnemyPos.positions : " + AddressHelper.GetAddress(AttackPos.positions));*/
        }


        /*public void setUID(string uid)
        {
            user_id = uid;
            sailor = new Player(uid);
        }*/

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
                completeConnector.GetSocket().Send(player.getUID());
        }
        public void ShipHitCheck(int ship_index, string uid)
        {
            //string attackOption = FindShipByIndex(PlayerPos, ship_index);
            string attackOption = PlayerPos.GetShipValue(ship_index);
            if (attackOption == "S")
            {
                MarkLocalShip(ship_index, true);
                responseConnector.GetSocket().Send($"{uid}:{ship_index}:{true}");
            }
            else
            {
                MarkLocalShip(ship_index, false);
                responseConnector.GetSocket().Send($"{uid}:{ship_index}:{false}");
            }
        }
        public void UpdateHitShips(int ship_index, string uid, bool hit_status)
        {
            if (player.getUID() != uid)//Nuo cia*
            {
                //Button attackedShip = FindShipByIndex(PlayerPos, ship_index);
                string attackOption = PlayerPos.GetShipValue(ship_index);
                //MarkShip(attackedShip, hit_status);
                MarkLocalShip(ship_index, hit_status);
            }
            else //Iki cia
            if (player.getUID() == uid)
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
                positionsConnector.GetSocket().Send($"{index}:{player.getUID()}");
            }
            turnConnector.GetSocket().Send($"{player.getUID()}");
        }

        public void Completed(string uid)
        {
            if (player.getUID() == uid)
            {
                positionsConnector.GetSocket().Close();
                responseConnector.GetSocket().Close();
                completeConnector.GetSocket().Close();
                MessageBox.Show("You are the winner");
                Application.Exit();
            }
            else
            {
                positionsConnector.GetSocket().Close();
                responseConnector.GetSocket().Close();
                completeConnector.GetSocket().Close();
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
                UpdateScore();
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
                IncreaseScore();
                UpdateScore();
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

        delegate void WriteMessageToBox(string message, string uid);
        public void WriteMessageToChatBox(string message, string uid)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (GameObjects.score_val.InvokeRequired)
            {
                WriteMessageToBox d = new WriteMessageToBox(WriteMessageToChatBox);
                Game.Invoke(d, new object[] { uid, message });
            }
            else
            {
                GameObjects.chatbox.Text += $"User({uid}) : {message}\n";
            }
        }

    }
}
