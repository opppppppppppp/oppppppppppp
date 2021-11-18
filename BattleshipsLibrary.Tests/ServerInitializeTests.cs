using Battleships.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BattleshipsLibrary.Tests
{
    public class ServerInitializeTests
    {
        [Fact]
        public void ServerInitialize_Valid()
        {
            bool value = Server.InitializeServer();

            Assert.True(value);
        }

        /*[Fact]
        public void ServerInitialize_Invalid()
        {
            Assert.Throws<TypeInitializationException>(() => Server.InitializeServer());
        }*/

    }
}
