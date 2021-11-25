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
    public class StrategyTests
    {

        private static ShipFactory Ships = new ShipSmallFactory();
        private static ShipField shipField;

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void missileAttackStrategyInitiliazeTest(int FieldSize)
        {
            //Arrange
            shipField = new ShipField(FieldSize, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            List<string> attackships = shipField.GetPositions();
            MissileAttackStrategy missileAttackStrategy = new MissileAttackStrategy();
            List<string> expected = returnSamplePositions(missileAttackStrategy.shipCount);

            //Act
            var strategyMock = new Mock<MissileAttackStrategy>();
            strategyMock.Setup(x => x.GetAttackingShips(attackships)).Returns(returnSamplePositions(missileAttackStrategy.shipCount));
            List<string> actual = strategyMock.Object.GetAttackingShips(attackships);

            //Assert
            Assert.True(actual.SequenceEqual(expected));
           
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void DynamiteAttackStrategyInitiliazeTest(int FieldSize)
        {
            //Arrange
            shipField = new ShipField(FieldSize, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            List<string> attackships = shipField.GetPositions();
            DynamiteAttackStrategy dynamiteAttackStrategy = new DynamiteAttackStrategy();
            List<string> expected = returnSamplePositions(dynamiteAttackStrategy.shipCount);

            //Act
            var strategyMock = new Mock<DynamiteAttackStrategy>();
            strategyMock.Setup(x => x.GetAttackingShips(attackships)).Returns(returnSamplePositions(dynamiteAttackStrategy.shipCount));
            List<string> actual = strategyMock.Object.GetAttackingShips(attackships);

            //Assert
            Assert.True(actual.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void BombAttackStrategyInitiliazeTest(int FieldSize)
        {
            //Arrange
            shipField = new ShipField(FieldSize, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            List<string> attackships = shipField.GetPositions();
            BombAttackStrategy bombAttackStrategy = new BombAttackStrategy();
            List<string> expected = returnSamplePositions(bombAttackStrategy.shipCount);

            //Act
            var strategyMock = new Mock<BombAttackStrategy>();
            strategyMock.Setup(x => x.GetAttackingShips(attackships)).Returns(returnSamplePositions(bombAttackStrategy.shipCount));
            List<string> actual = strategyMock.Object.GetAttackingShips(attackships);

            //Assert
            Assert.True(actual.SequenceEqual(expected));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void atomicBombAttackStrategyInitializeTest(int FieldSize)
        {
            //Arrange
            shipField = new ShipField(FieldSize, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
            List<string> attackships = shipField.GetPositions();
            AtomicBombAttackStrategy atomicBombStrategy = new AtomicBombAttackStrategy();
            List<string> expected = returnSamplePositions(atomicBombStrategy.shipCount);

            //Act
            var strategyMock = new Mock<AtomicBombAttackStrategy>();
            strategyMock.Setup(x => x.GetAttackingShips(attackships)).Returns(returnSamplePositions(atomicBombStrategy.shipCount));
            List<string> actual = strategyMock.Object.GetAttackingShips(attackships);

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
