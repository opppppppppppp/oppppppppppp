using Battleships.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BattleshipsLibrary.Tests
{
    public class ServerTests
    {
        [Fact]
        public void ServerInitializeTest()
        {
            bool value = Server.InitializeServer();

            Assert.True(value);
        }

        [Fact]
        public void ServerConnectTestFail()
        {
            //Assert.Throws<InvalidOperationException>(() => Client.Connect("127.0.0.157890"));
        }

        [Fact]
        public void ServerConnectTest()
        {
            Server.InitializeServer();
            //object ws = Client.Connect("127.0.0.1:7890");
            //Assert.NotNull(ws);
        }

    }
}
