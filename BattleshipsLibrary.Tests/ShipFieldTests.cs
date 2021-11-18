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

namespace BattleshipsLibrary.Tests
{
    public class ShipFieldTests
    {
        private static GameObjects gObjects;
        private static ShipFactory Ships = new ShipSmallFactory();
        private static ShipField ttt = new ShipField(6, gObjects.player_table, new ShipFieldUpgradeGood(), Ships);

        [Fact]
        public void GetPositions_Valid()
        {
            List<string> pos = ttt.GetPositions();

            Console.WriteLine(pos.Count());

        }

    }
}
