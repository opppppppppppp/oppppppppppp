using Battleships.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BattleshipsLibrary.Tests
{
    public class SailorTest
    {
        [Fact]
       
        public void SailorInitTest()
        {
            var mockSailor = new Mock<Sailor>();

            string expected = "123";
            mockSailor.Setup(x => x.assignUID("123"));
            mockSailor.Setup(x => x.getUID()).Returns(expected);
            Sailor actualSailor = new Sailor();
            actualSailor.assignUID(expected);
            Assert.Equal(actualSailor.getUID(), mockSailor.Object.getUID());
        }
    }
}
