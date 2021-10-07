using Battleships.Models.ConcreteCreator;
using Battleships.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.LevelBuilder
{
    class LevelThreeBuilder : ILevelBuilder
    {
        Level level = new Level();

        public void SetTitle()
        {
            level.Title = "Level 3 - TERRORISTS WIN";
        }

        public void SetNumberOfShips()
        {
            level.NumberOfShips = 6;
            level.ShipFactory = new ShipBigFactory(6);
        }

        public void SetStrategy()
        {
            level.Strategy = new MissileAttackStrategy();
        }


        public Level GetLevel()
        {
            return level;
        }
    }
}
