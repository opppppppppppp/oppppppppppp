using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.LevelBuilder
{
    public class LevelOneBuilder : ILevelBuilder 
    {
        Level level = new Level();
        public void SetTitle()
        {
            level.Title = "Level 1 - Paradise of hell";
        }
        public void SetNumberOfShips()
        {
            level.NumberOfShips = 4;
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
