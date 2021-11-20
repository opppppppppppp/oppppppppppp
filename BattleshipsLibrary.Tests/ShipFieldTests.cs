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
  

    public class ShipFieldTests
    {


        private readonly ITestOutputHelper _testOutputHelper;
        public ShipFieldTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

       
     
        [Theory]
        [InlineData(5,25)]
        public void GetPositionsCount_Valid(int numberOfFields, int expected)
        { 
            private static ShipFactory Ships = new ShipSmallFactory();
            private static ShipField ttt = new ShipField(numberOfFields, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            List<string> pos = ttt.GetPositions();
            
            
            Assert.Equal(expected, pos.Count());

        }

    }
}
