﻿using Battleships.Models.ConcreteCreator;
using Battleships.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.LevelBuilder
{
    class LevelTwoBuilder : ILevelBuilder
    {
        Level level = new Level();

        public void SetTitle()
        {
            level.Title = "Level 2 - Cariebien of the Pirates";
        }

        public void SetNumberOfShips()
        {
            level.NumberOfShips = 5;
            level.ShipFactory = new ShipMediumFactory(5);
        }

        public void SetStrategy()
        {
            level.Strategy = new DynamiteAttackStrategy();
        }


        public Level GetLevel()
        {
            return level;
        }
    }
}