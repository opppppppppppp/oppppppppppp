using Battleships.Models.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BattleshipsLibrary.Tests
{
    public class CommandTests
    {

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void TestAddScore(int scoreValue)
        {
            ScoreCalculator calculator = new ScoreCalculator();
            calculator.ExecuteCommand(new AddScoreCommand(scoreValue));
            Assert.Equal(scoreValue, calculator.score);
        }

        [Fact]
        public void TestUndoScore()
        {
            ScoreCalculator calculator = new ScoreCalculator();
            calculator.ExecuteCommand(new AddScoreCommand(4));
            calculator.ExecuteCommand(new AddScoreCommand(2));
            calculator.Undo();
            Assert.Equal(4, calculator.score);
        }

  


    }
}
