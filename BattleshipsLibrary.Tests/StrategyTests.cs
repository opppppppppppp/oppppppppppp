using Battleships;
using Battleships.Models;
using Battleships.Models.Decorator;
using Battleships.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Models.Bridge;
using Xunit;
using Xunit.Abstractions;
using System.Windows.Forms;

namespace BattleshipsLibrary.Tests
{
    public class StrategyTests
    {

        private static ShipFactory Ships = new ShipSmallFactory();
        private static ShipField shipField;

        [Fact]
        public void basicAttackTest()
        {
            shipField = new ShipField(5, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            MissileAttackStrategy missileAttackStrategy = new MissileAttackStrategy();
            var shipsCount = missileAttackStrategy.GetAttackingShips(shipField.GetPositions()).Count;
            Assert.Equal(1, shipsCount);
        }

        [Fact]
        public void bombAttackTest()
        {
            shipField = new ShipField(5, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            BombAttackStrategy missileAttackStrategy = new BombAttackStrategy();
            var shipsCount = missileAttackStrategy.GetAttackingShips(shipField.GetPositions()).Count;
            Assert.Equal(3, shipsCount);
        }
        [Fact]
        public void dynamiteAttackTest()
        {
            shipField = new ShipField(5, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            DynamiteAttackStrategy missileAttackStrategy = new DynamiteAttackStrategy();
            var shipsCount = missileAttackStrategy.GetAttackingShips(shipField.GetPositions()).Count;
            Assert.Equal(2, shipsCount);
        }
    }
}
