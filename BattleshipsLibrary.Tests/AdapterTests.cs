﻿using Battleships.LevelBuilder;
using Battleships.Models;
using Battleships.Models.Adapter;
using Battleships.Models.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BattleshipsLibrary.Tests
{
    public class AdapterTests
    {
        [Fact]
        public void PositionGenerationTest()
        {
            LevelCreator levelcreator = new LevelCreator(new LevelOneBuilder());
            levelcreator.CreateLevel();
            Level lvl = levelcreator.GetLevel();
            ShipFactory Ships = new ShipSmallFactory();
            ShipField shipField = new ShipField(5, new System.Windows.Forms.DataGridView(), new ShipFieldUpgradeGood(), Ships);
            List<int> positions = new Pos().generatePos(0, lvl, shipField);
            Assert.Equal(lvl.NumberOfShips, positions.Count);

        }
    }
}
