using Battleships.Models.Factory_Method.ConcreteOrangeProduct;
using Battleships.Models.Factory_Method.ConcreteProduct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    class ShipSmallFactory : ShipFactory
    {
        private Color _Color;

        public ShipSmallFactory()
        {

        }

        public override OrangeShip GetOrangeShip()
        {
            return new SmallOrangeShip();
        }

        public override BlueShip GetBlueShip()
        {
            return new SmallBlueShip();
        }
    }
}
