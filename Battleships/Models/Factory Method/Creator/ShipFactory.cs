using Battleships.Models.Factory_Method.ConcreteOrangeProduct;
using Battleships.Models.Factory_Method.ConcreteProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public abstract class ShipFactory
    {
        public abstract BlueShip GetBlueShip(); // default blue

        public abstract OrangeShip GetOrangeShip();
    }
}
