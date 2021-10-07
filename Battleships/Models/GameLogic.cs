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
        public List<Button> PlayerPos { get; set; }
        public List<Button> EnemyPos { get; set; }
        public List<Button> AttackPos { get; set; }
        public List<int> SelectedPlayerPos { get; set; }
        public ShipFactory Ships { get; set; }

        public int playerScore = 0;
        public int currentLevel = 1;
        public int Score = 0;

        public GameLogic() { }
        public GameLogic(List<Button> playerPositions, List<Button> enemyPositions, ShipFactory ships)
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
                int number = rnd.Next(1, 24);
                if (!positions.Contains(number))
                {
                    positions.Add(number);
                }
            }
            return positions;
        }

        public int GetEnemyShipIndex(Button ship)
        {
            return EnemyPos.IndexOf(ship);
        }

        public void MarkShipColor(List<Button> Pos, List<int> selectedPos)
        {
            for (int i = 0; i < selectedPos.Count; i++)
            {
                int index = selectedPos[i];
                Pos[index].BackColor = Color.Green;
            }
        }

        public void MarkShipTag(List<Button> Pos, List<int> selectedPos)
        {
            for (int i = 0; i < selectedPos.Count; i++)
            {
                int index = selectedPos[i];
                Pos[index].Tag = "Ship";
            }
        }

        public void MarkShip(Button Ship, bool hit_status)
        {
            Ship.Invoke((MethodInvoker)(() =>
            {
                if (hit_status)
                {
                    Ship.BackColor = Color.Red;
                    Ship.Text = "X";
                    MessageBox.Show("You've hit enemy ship!");
                    playerScore++;
                    IncreaseScore();
                    //ScoreChecker();
                }
                else
                {
                    Ship.BackColor = Color.Red;
                }
            }));
        }

        public void RemoveShipFromAttackTable(Button Ship)
        {
            AttackPos.Remove(Ship);
        }

        public Button FindShipByIndex(List<Button> positions, int index)
        {
            return positions[index];
        }

        public void RestartGame()
        {   
            AttackPos = EnemyPos;

            for (int i = 0; i < PlayerPos.Count; i++)
            {
                PlayerPos[i].BackColor = Color.White;
                EnemyPos[i].BackColor = Color.White;

                PlayerPos[i].Tag = null;
                EnemyPos[i].Tag = null;
            }
            playerScore = 0;

            SelectedPlayerPos = generateRandomPos();

            MarkShipColor(PlayerPos, SelectedPlayerPos);
            MarkShipTag(PlayerPos, SelectedPlayerPos);
        }

        public void IncreaseScore()
        {
            Score++;
        }


    }
}
