using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Factory_Method.ConcreteOrangeProduct
{
    class BigOrangeShip : OrangeShip
    {
        private readonly string _ShipType;
        public BigOrangeShip()
        {
            _ShipType = "Big";
            ShipSize = 3;
        }

        public override string ShipType
        {
            get { return _ShipType; }
        }

        public override Color _Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
    }
}
