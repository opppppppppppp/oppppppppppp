using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    class ShipSmallFactory : ShipFactory
    {
        private int _ShipSize;

        public ShipSmallFactory(int shipSize)
        {
            _ShipSize = shipSize;
        }

        public override Ship GetShip()
        {
            return new ShipMedium(_ShipSize);
        }
    }
}
