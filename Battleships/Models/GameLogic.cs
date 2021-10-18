using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battleships.Models.Command;

namespace Battleships.Models
{
    public class GameLogic
    {
        public ShipField PlayerPos { get; set; }
        public ShipField EnemyPos { get; set; }
        public ShipField AttackPos { get; set; }
        public List<int> SelectedPlayerPos { get; set; }
        public ShipFactory Ships { get; set; }

        public int playerScore = 0;
        public int currentLevel = 1;
        public ScoreCalculator scoreCalculator = new ScoreCalculator();

        public GameLogic()
        {
        }
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
                    MessageBox.Show("You've hit enemy ship!");
                    playerScore++;
                    IncreaseScore();
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
                MessageBox.Show("You've hit enemy ship!");
                playerScore++;
                IncreaseScore();
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
            SelectedPlayerPos = generateRandomPos();
            MarkSelectedShips(PlayerPos, SelectedPlayerPos);
        }
        public void IncreaseScore()
        {
            scoreCalculator.ExecuteCommand(new AddScoreCommand(1));
        }
    }
}
