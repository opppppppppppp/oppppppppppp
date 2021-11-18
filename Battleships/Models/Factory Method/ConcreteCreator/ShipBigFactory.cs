using Battleships.Models.Factory_Method.ConcreteOrangeProduct;
using Battleships.Models.Factory_Method.ConcreteProduct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.ConcreteCreator
{
    public class ShipBigFactory : ShipFactory
    {
        private Color _Color;

        public ShipBigFactory()
        {

        }

        public override OrangeShip GetOrangeShip()
        {
            return new BigOrangeShip();
        }

        public override BlueShip GetBlueShip()
        {
            return new BigBlueShip();
        }

       
    }
}
