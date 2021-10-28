using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Factory_Method.ConcreteOrangeProduct
{
    class MediumOrangeShip : OrangeShip
    {
        private readonly string _ShipType;

        public MediumOrangeShip()
        {
            _ShipType = "Medium";
            ShipSize = 2;
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
