using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.ConcreteCreator
{
    class ShipBigFactory : ShipFactory
    {
        private int _ShipSize;

        public ShipBigFactory(int shipSize)
        {
            _ShipSize = shipSize;
        }

        public override Ship GetShip()
        {
            return new ShipBig(_ShipSize);
        }
    }
}
