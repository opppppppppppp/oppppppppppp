using Battleships.Models;
using Battleships.Models.ConcreteCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BattleshipsLibrary.Tests
{
    public class FactoryTests
    {
        [Fact]
        public void SmallShipFactoryInitializeTest()
        {
            //Arrange
            ShipFactory expected = new ShipSmallFactory(2);

            //Act
            ShipFactory actual = new ShipSmallFactory(2);

            //Assert
            Assert.True(actual.Equals(expected));
        }

        [Fact]
        public void MediumShipFactoryInitializeTest()
        {
            //Arrange
            ShipFactory expected = new ShipMediumFactory(2);

            //Act
            ShipFactory actual = new ShipMediumFactory(2);

            //Assert
            Assert.True(actual.Equals(expected));
        }

        [Fact]
        public void BigShipFactoryInitializeTest()
        {
            //Arrange
            ShipFactory expected = new ShipBigFactory(2);

            //Act
            ShipFactory actual = new ShipBigFactory(2);

            //Assert
            Assert.True(actual.Equals(expected));
        }
    }
}
