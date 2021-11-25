
using Xunit;
using Battleships.LevelBuilder;
using Battleships.Models;

namespace BattleshipsLibrary.Tests
{
    public class BuilderTests
    {

        [Fact]
        public void LevelOneBuilderTest()
        {
            //Arrange
            Level expected = new Level();
            expected.Title = "Level 1 - Paradise of hell";
          
            expected.ShipFactory = new ShipSmallFactory(2);
            expected.NumberOfShips = 4;
      

            //Act
            LevelCreator levelcreator = new LevelCreator(new LevelOneBuilder());
            levelcreator.CreateLevel();
            Level lvl = levelcreator.GetLevel();

            //Assert
            Assert.True(lvl.Equals(expected));
        }

        [Fact]
        public void LevelTwoBuilderTest()
        {
            //Arrange
            Level expected = new Level();
            expected.Title = "Level 2 - Cariebien of the Pirates";
            expected.ShipFactory = new ShipSmallFactory(2);
            expected.NumberOfShips = 5;

            //Act
            LevelCreator levelcreator = new LevelCreator(new LevelTwoBuilder());
            levelcreator.CreateLevel();
            Level lvl = levelcreator.GetLevel();

            //Assert
            Assert.True(lvl.Equals(expected));
        }


        [Fact]
        public void LevelThreeBuilderTest()
        {
            //Arrange
            Level expected = new Level();
            expected.Title = "Level 3 - Island of the Terror";
            expected.ShipFactory = new ShipSmallFactory(2);
            expected.NumberOfShips = 6;

            //Act
            LevelCreator levelcreator = new LevelCreator(new LevelThreeBuilder());
            levelcreator.CreateLevel();
            Level lvl = levelcreator.GetLevel();

            //Assert
            Assert.True(lvl.Equals(expected));
        }

    }
}
