using Battleships;
using Battleships.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;
using System.Windows.Forms;
using Moq;

namespace BattleshipsLibrary.Tests
{


    public class ShipFieldTests
    {


        private readonly ITestOutputHelper _testOutputHelper;
        public ShipFieldTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private static ShipFactory Ships = new ShipSmallFactory(2);
        private static ShipField shipField;
        private static DataGridView dataGridView = new DataGridView();
        [Theory]
        [InlineData(5, 25)]
        [InlineData(6, 36)]
        [InlineData(8, 64)]
        public void PosCountTest(int numberOfFields, int expected)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), Ships);
            List<string> pos = shipField.GetPositions();


            Assert.Equal(expected, pos.Count());
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        public void addRowsTest(int numberOfFields, int expectedRows)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), Ships);
            var table = shipField.GetTableData();

            Assert.Equal(expectedRows, table.Rows.Count);
        }


        [Theory]
        [InlineData(5, 5)]
        [InlineData(6, 6)]
        public void addColunmsTest(int numberOfFields, int expectedRows)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), Ships);
            var table = shipField.GetTableData();

            Assert.Equal(expectedRows, table.Columns.Count);
        }

        [Theory]
        [InlineData(5, 3, 0)]
        [InlineData(5, 25, 5)]
        public void getRowTest(int numberOfFields, int index, int expected)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), Ships);
            var actual = shipField.GetRow(index);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 0, 0)]
        [InlineData(5, 24, 4)]
        public void getColumnTest(int numberOfFields, int index, int expected)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), Ships);
            var actual = shipField.GetColumn(index);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 0, "A1")]
        [InlineData(5, 1, "A2")]
        public void getShipIndexTest(int numberOfFields, int index, string expected)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), Ships);
            var actual = shipField.GetShipIndex(expected);
            Assert.Equal(actual, index);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void getTableSizeTest(int numberOfFields)
        {
            shipField = new ShipField(numberOfFields, new DataGridView(), Ships);
            var actual = shipField.GetTableSize();
            Assert.Equal(actual, numberOfFields* numberOfFields);
        }



    }
}
