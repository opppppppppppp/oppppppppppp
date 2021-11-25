
using Xunit;
using Battleships.LevelBuilder;
using Battleships.Models.Strategy;
using Battleships.Models.Decorator;
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
            expected.Strategy = new BombAttackStrategy();
            expected.ShipFactory = new ShipSmallFactory();
            expected.NumberOfShips = 4;
            expected.IncreasedStrategy = new UltraAttackIncrease(new BombAttackStrategy());

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
            expected.Strategy = new DynamiteAttackStrategy();
            expected.ShipFactory = new ShipSmallFactory();
            expected.NumberOfShips = 5;
            expected.IncreasedStrategy = new MediumAttackIncrease(new DynamiteAttackStrategy());

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
            expected.Strategy = new MissileAttackStrategy();
            expected.ShipFactory = new ShipSmallFactory();
            expected.NumberOfShips = 6;
            expected.IncreasedStrategy = new BasicAttackIncrease(new MissileAttackStrategy());

            //Act
            LevelCreator levelcreator = new LevelCreator(new LevelThreeBuilder());
            levelcreator.CreateLevel();
            Level lvl = levelcreator.GetLevel();

            //Assert
            Assert.True(lvl.Equals(expected));
        }

    }
}
