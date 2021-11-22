
using Xunit;
using Battleships.LevelBuilder;
using Battleships.Models.Strategy;

namespace BattleshipsLibrary.Tests
{
    public class BuilderTests
    {

        [Fact]
        public void LevelOneBuilderTest()
        {
            LevelCreator levelcreator = new LevelCreator(new LevelOneBuilder());
            levelcreator.CreateLevel();
            Level lvl = levelcreator.GetLevel();
            Assert.Equal(lvl.Strategy.GetType(), (new BombAttackStrategy().GetType()));
        }

        [Fact]
        public void LevelTwoBuilderTest()
        {
            LevelCreator levelcreator = new LevelCreator(new LevelTwoBuilder());
            levelcreator.CreateLevel();
            Level lvl = levelcreator.GetLevel();
            Assert.Equal(lvl.Strategy.GetType(), (new DynamiteAttackStrategy().GetType()));
        }


        [Fact]
        public void LevelThreeBuilderTest()
        {
            LevelCreator levelcreator = new LevelCreator(new LevelThreeBuilder());
            levelcreator.CreateLevel();
            Level lvl = levelcreator.GetLevel();
            Assert.Equal(lvl.Strategy.GetType(), (new MissileAttackStrategy().GetType()));
        }

    }
}
