using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    abstract class ShipFactory
    {
        public abstract Ship GetShip();
    }
}
