using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public abstract class ShipFactory
    {
        public abstract Ship GetShip();
    }
}
