using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Factory_Method.ConcreteProduct
{
    public abstract class BlueShip
    {
        public abstract string ShipType { get; }
        public abstract Color _Color { get; set; }

        public BlueShip()
        {
            _Color = Color.LightBlue;
        }
    }
}
