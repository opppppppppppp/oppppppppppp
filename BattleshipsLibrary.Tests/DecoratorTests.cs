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
    public class DecoratorTests
    {
        [Fact]
        public void BasicAttackIncreaseTest()
        {
            IAttackStrategy IncreasedStrategy = new BasicAttackIncrease(new BombAttackStrategy());
            Assert.Equal(6, IncreasedStrategy.shipCount);
        }

        [Fact]
        public void MediumAttackIncreaseTest()
        {
            IAttackStrategy IncreasedStrategy = new MediumAttackIncrease(new BombAttackStrategy());
            Assert.Equal(9, IncreasedStrategy.shipCount);
        }

        [Fact]
        public void UltraAttackIncreaseTest()
        {
            IAttackStrategy IncreasedStrategy = new UltraAttackIncrease(new BombAttackStrategy());
            Assert.Equal(12, IncreasedStrategy.shipCount);
        }
    }
}
