using Battleships.Models;

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
           ShipFactory Ships = new ShipSmallFactory(2);
           ShipField shipField;
           DataGridView dataGridView = new DataGridView();
           shipField = new ShipField(1, new DataGridView(), Ships);
           var Ship = shipField.Clone();

           Assert.IsType(shipField.GetType(), Ship);
        }
    }
}
