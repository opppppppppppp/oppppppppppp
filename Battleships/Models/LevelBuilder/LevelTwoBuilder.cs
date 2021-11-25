using Battleships.Models;
using Battleships.Models.ConcreteCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.LevelBuilder
{
    public class LevelTwoBuilder : ILevelBuilder
    {
        Level level = new Level();
        public void SetTitle()
        {
            level.Title = "Level 2 - Cariebien of the Pirates";
        }
        public void SetNumberOfShips()
        {
            level.NumberOfShips = 5;
            level.ShipFactory = new ShipSmallFactory(2);
        }

        public void SetStrategy()
        {
          
        }

        public void IncreasedStrategy()
        {
            
        }

        public Level GetLevel()
        {
            return level;
        }
    }
}
