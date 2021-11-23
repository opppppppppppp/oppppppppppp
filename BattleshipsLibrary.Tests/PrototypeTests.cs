using Battleships.Models;
using Battleships.Models.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;

namespace BattleshipsLibrary.Tests
{
    public class PrototypeTests
    {
        [Fact]
        public void CloneTest()
        {
           ShipFactory Ships = new ShipSmallFactory();
           ShipField shipField;
           DataGridView dataGridView = new DataGridView();
           shipField = new ShipField(1, new DataGridView(), new ShipFieldUpgradeGood(), Ships);
           var Ship = shipField.Clone();

           Assert.IsType(shipField.GetType(), Ship);
        }
    }
}
