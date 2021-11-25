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
using Moq;

namespace BattleshipsLibrary.Tests
{
    public class DecoratorTests
    {
        private static ShipFactory Ships = new ShipSmallFactory(2);
        private static ShipField shipField;

        /*[Fact]
        public void BasicAttackIncreaseTest()
        {
            IAttackStrategy IncreasedStrategy = new BasicAttackIncrease(new BombAttackStrategy());
            Assert.Equal(6, IncreasedStrategy.shipCount);
        }*/

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void BasicAttackIncreaseTest(int FieldSize)
        {
            //Arrange
            shipField = new ShipField(FieldSize, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            List<string> attackships = shipField.GetPositions();
            AttackIncreaseDecorator IncreasedStrategy = new BasicAttackIncrease(new BombAttackStrategy());
            List<string> expected = returnSamplePositions(IncreasedStrategy.shipCount);

            //Act
            var decoratorMock = new Mock<AttackIncreaseDecorator>(IncreasedStrategy);
            decoratorMock.Setup(x => x.GetAttackingShips(attackships)).Returns(returnSamplePositions(IncreasedStrategy.shipCount));
            List<string> actual = decoratorMock.Object.GetAttackingShips(attackships);

            //Assert
            Assert.True(actual.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void MediumAttackIncreaseTest(int FieldSize)
        {
            //Arrange
            shipField = new ShipField(FieldSize, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            List<string> attackships = shipField.GetPositions();
            AttackIncreaseDecorator IncreasedStrategy = new MediumAttackIncrease(new BombAttackStrategy());
            List<string> expected = returnSamplePositions(IncreasedStrategy.shipCount);

            //Act
            var decoratorMock = new Mock<AttackIncreaseDecorator>(IncreasedStrategy);
            decoratorMock.Setup(x => x.GetAttackingShips(attackships)).Returns(returnSamplePositions(IncreasedStrategy.shipCount));
            List<string> actual = decoratorMock.Object.GetAttackingShips(attackships);

            //Assert
            Assert.True(actual.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void UltraAttackIncreaseTest(int FieldSize)
        {
            //Arrange
            shipField = new ShipField(FieldSize, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            List<string> attackships = shipField.GetPositions();
            AttackIncreaseDecorator IncreasedStrategy = new UltraAttackIncrease(new BombAttackStrategy());
            List<string> expected = returnSamplePositions(IncreasedStrategy.shipCount);
            var name = IncreasedStrategy.Name;
            var count = IncreasedStrategy.shipCount;

            //Act
            var decoratorMock = new Mock<AttackIncreaseDecorator>(IncreasedStrategy);
            decoratorMock.Setup(x => x.GetAttackingShips(attackships)).Returns(returnSamplePositions(IncreasedStrategy.shipCount));
            List<string> actual = decoratorMock.Object.GetAttackingShips(attackships);

            //Assert
            Assert.True(actual.SequenceEqual(expected));
        }

        private List<string> returnSamplePositions(int size)
        {
            List<string> pos = new List<string>();
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int i = 1; i <= size; i++)
            {
                pos.Add((letters[i].ToString() + i.ToString()));
            }
            return pos;
        }

    }
}
