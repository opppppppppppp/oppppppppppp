using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    abstract class Ship
    {
        public abstract string ShipType { get; }
        public abstract int ShipCount { get; set; }
    }
}
