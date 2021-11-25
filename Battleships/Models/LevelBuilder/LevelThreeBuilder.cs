using Battleships.Models;
using Battleships.Models.ConcreteCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.LevelBuilder
{
    public class LevelThreeBuilder : ILevelBuilder
    {
        Level level = new Level();
        public void SetTitle()
        {
            level.Title = "Level 3 - Island of the Terror";
        }
        public void SetNumberOfShips()
        {
            level.NumberOfShips = 6;
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
