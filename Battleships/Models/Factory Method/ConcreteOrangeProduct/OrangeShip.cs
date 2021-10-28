using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Factory_Method.ConcreteOrangeProduct
{
    public abstract class OrangeShip
    { 
        public abstract string ShipType { get; }
        public int ShipSize { get; set; }
        public abstract Color _Color { get; set; }

        public OrangeShip()
        {
            _Color = Color.Orange;
        }
    }
}
