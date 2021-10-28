using Battleships.Models.Factory_Method.ConcreteProduct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    class SmallBlueShip : BlueShip
    {
        private readonly string _ShipType;

        public SmallBlueShip()
        {
            _ShipType = "Small";
            ShipSize = 1;
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
