using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships.Models
{
    public class GameLogic
    {
        //public List<Button> PlayerPos { get; set; }
        //public List<Button> EnemyPos { get; set; }
        //public List<Button> AttackPos { get; set; }
        public ShipField PlayerPos { get; set; }
        public ShipField EnemyPos { get; set; }
        public ShipField AttackPos { get; set; }
        public List<int> SelectedPlayerPos { get; set; }
        public ShipFactory Ships { get; set; }

        public int playerScore = 0;
        public int currentLevel = 1;
        public int Score = 0;

        public GameLogic() { }
        public GameLogic(ShipField playerPositions, ShipField enemyPositions, ShipFactory ships)
        {
            PlayerPos = playerPositions;
            EnemyPos = enemyPositions;
            AttackPos = enemyPositions;
            Ships = ships;
            SelectedPlayerPos = generateRandomPos();
        }

        private List<int> generateRandomPos()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<int> positions = new List<int>();
            while (positions.Count != Ships.GetShip().ShipSize)
            {
                int number = rnd.Next(1, PlayerPos.GetTableSize() - 1);
                if (!positions.Contains(number))
                {
                    positions.Add(number);
                }
            }
            return positions;
        }


        /*public int GetEnemyShipIndex(string ship)
        {
            return EnemyPos.GetShipIndex(ship);
        }

        public void GetEnemyShip(int index)
        {
            return Ene
        }*/

        public void MarkSelectedShips(ShipField Pos, List<int> selectedPos)
        {
            for (int i = 0; i < selectedPos.Count; i++)
            {
                int index = selectedPos[i];
                Pos.MarkShip(index);
            }
        }

        /*public void MarkShipTag(List<string> Pos, List<int> selectedPos)
        {
            for (int i = 0; i < selectedPos.Count; i++)
            {
                int index = selectedPos[i];
                Pos[index].Tag = "Ship";
            }
        }*/

        public void MarkLocalShip(int ship_index, bool hit_status)
        {
            //Ship.Invoke((MethodInvoker)(() =>
            //{
                if (hit_status)
                {
                    PlayerPos.MarkDestroyedShip(ship_index);
                    //Ship.BackColor = Color.Red;
                    //Ship.Text = "X";
                    MessageBox.Show("You've hit enemy ship!");
                    playerScore++;
                    IncreaseScore();
                    //ScoreChecker();
                }
                else
                {
                    PlayerPos.MarkHitShip(ship_index);
                }
            //}));
        }

        public void MarkEnemyShip(int ship_index, bool hit_status)
        {
            //Ship.Invoke((MethodInvoker)(() =>
            //{
            if (hit_status)
            {
                EnemyPos.MarkDestroyedShip(ship_index);
                //Ship.BackColor = Color.Red;
                //Ship.Text = "X";
                MessageBox.Show("You've hit enemy ship!");
                playerScore++;
                IncreaseScore();
                //ScoreChecker();
            }
            else
            {
                EnemyPos.MarkHitShip(ship_index);
                //Ship.BackColor = Color.Red;
            }
            //}));
        }

        public void RemoveShipFromAttackTable(Button Ship)
        {
            //AttackPos.Remove(Ship);
        }
        public Button FindShipByIndex(List<Button> positions, int index)
        {
            return positions[index];
        }
        public void RestartGame()
        {   
            AttackPos = EnemyPos;

            //PlayerPos.ForEach(p => ResetShips(p));
            //EnemyPos.ForEach(p => ResetShips(p));
            playerScore = 0;

            SelectedPlayerPos = generateRandomPos();

            MarkSelectedShips(PlayerPos, SelectedPlayerPos);
            //MarkShipTag(PlayerPos, SelectedPlayerPos);
        }
        private void ResetShips(Button ShipPos)
        {
            //ShipPos.BackColor = Color.White;
            //ShipPos.Tag = null;
        }
        public void IncreaseScore()
        {
            Score++;
        }


    }
}
