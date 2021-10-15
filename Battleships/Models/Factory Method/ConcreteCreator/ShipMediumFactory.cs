using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.ConcreteCreator
{
    class ShipMediumFactory : ShipFactory
    {
        private int _ShipSize;

        public ShipMediumFactory(int shipSize)
        {
            _ShipSize = shipSize;
        }

        public override Ship GetShip()
        {
            return new ShipMedium(_ShipSize);
        }
    }
}
