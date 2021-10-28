using Battleships.Models.Factory_Method.ConcreteProduct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    class MediumBlueShip : BlueShip
    {
        private readonly string _ShipType;

        public MediumBlueShip()
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
