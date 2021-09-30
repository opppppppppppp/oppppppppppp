using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    class ShipMedium : Ship
    {
        private readonly string _ShipType;
        private int _ShipSize;

        public ShipMedium(int ShipSize)
        {
            _ShipType = "Medium";
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
