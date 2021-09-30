using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    class ShipSmall : Ship
    {
        private readonly string _ShipType;
        private int _ShipSize;

        public ShipSmall(int ShipSize)
        {
            _ShipType = "Small";
            _ShipSize = ShipSize;
        }

        public override string ShipType
        {
            get { return _ShipType; }
        }

        public override int ShipSize
        {
            get { return _ShipSize; }
            set { _ShipSize = value; }
        }

    }
}
