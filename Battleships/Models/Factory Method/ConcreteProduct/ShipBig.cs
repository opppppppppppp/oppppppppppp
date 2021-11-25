using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Factory_Method.ConcreteProduct
{
    class ShipBig : Ship
    {
        public readonly string _ShipType;
        public int _ShipSize;

        public ShipBig(int ShipSize)
        {
            _ShipType = "Big";
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

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var obj_new = obj as ShipBig;

            return obj_new._ShipSize == _ShipSize && obj_new._ShipType == _ShipType;
        }
    }
}
