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

        private static ShipFactory Ships = new ShipSmallFactory();
        private static ShipField shipField;
        private static DataGridView dataGridView = new DataGridView();
        [Theory]
        [InlineData(5, 25)]
        [InlineData(6, 36)]
        [InlineData(8, 64)]
        public void PosCountTest(int numberOfFields, int expected)
        {

            shipField = new ShipField(numberOfFields, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            List<string> pos = shipField.GetPositions();


            Assert.Equal(expected, pos.Count());
        }

        [Fact]
        public void CloneTest()
        {
            shipField = new ShipField(1, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            var Ship = shipField.Clone();

            Assert.IsType(shipField.GetType(), Ship);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        public void addRowsTest(int numberOfFields, int expectedRows)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            var table = shipField.GetTableData();

            Assert.Equal(expectedRows, table.Rows.Count);
        }


        [Theory]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        public void addColunmsTest(int numberOfFields, int expectedRows)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            var table = shipField.GetTableData();

            Assert.Equal(expectedRows, table.Columns.Count);
        }

        [Theory]
        [InlineData(5, 3, 0)]
        [InlineData(5, 25, 5)]
        public void getRowTest(int numberOfFields, int index, int expected)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            var actual = shipField.GetRow(index);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 0, 0)]
        [InlineData(5, 24, 4)]
        public void getColumnTest(int numberOfFields, int index, int expected)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            var actual = shipField.GetColumn(index);
            Assert.Equal(expected, actual);
        }


        //[Theory]
        //[InlineData(5, 0, "S")]
        //[InlineData(5, 24, "S")]
        //public void markShipTest(int numberOfFields, int index, string expected)
        //{



        //    shipField = new ShipField(numberOfFields, dataGridView, new ShipFieldUpgradeGood(), Ships);
        //    shipField.assignDataTableToDataGrindView();
        //    shipField.MarkShip(index);
        //}


        [Fact]
        public void basicAttackTest()
        {
            shipField = new ShipField(5, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            MissileAttackStrategy missileAttackStrategy = new MissileAttackStrategy();
            var shipsCount =  missileAttackStrategy.GetAttackingShips(shipField.GetPositions()).Count;
            Assert.Equal(1, shipsCount);
        }

        [Fact]
        public void bombAttackTest()
        {
            shipField = new ShipField(5, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            BombAttackStrategy missileAttackStrategy = new BombAttackStrategy();
            var shipsCount = missileAttackStrategy.GetAttackingShips(shipField.GetPositions()).Count;
            Assert.Equal(3, shipsCount);
        } [Fact]
        public void dynamiteAttackTest()
        {
            shipField = new ShipField(5, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            DynamiteAttackStrategy missileAttackStrategy = new DynamiteAttackStrategy();
            var shipsCount = missileAttackStrategy.GetAttackingShips(shipField.GetPositions()).Count;
            Assert.Equal(2, shipsCount);
        }




    }
}
