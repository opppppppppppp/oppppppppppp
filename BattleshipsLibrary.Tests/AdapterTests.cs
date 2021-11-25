using Battleships.LevelBuilder;
using Battleships.Models;
using Battleships.Models.Adapter;
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
        [Theory]
        [InlineData(5,1)]
        [InlineData(6,0)]
        public void positionGenerationTest(int FieldSize, int type)
        {
            //Arrange
            LevelCreator levelcreator = new LevelCreator(new LevelOneBuilder());
            levelcreator.CreateLevel();
            Level lvl = levelcreator.GetLevel();
            ShipFactory Ships = new ShipSmallFactory(2);
            ShipField shipField = new ShipField(FieldSize, new System.Windows.Forms.DataGridView(), Ships);
            List<int> positions = new Pos().generatePos(type, lvl, shipField);
            Assert.Equal(lvl.NumberOfShips, positions.Count);
        }
    }
}
