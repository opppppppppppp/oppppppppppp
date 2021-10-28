using Battleships.Models.Factory_Method.ConcreteProduct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class BigBlueShip : BlueShip
    {
        private readonly string _ShipType;
  

        public BigBlueShip()
        {
            _ShipType = "Big";
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
