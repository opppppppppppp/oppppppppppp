using Battleships.Models.Factory_Method.ConcreteProduct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.ConcreteCreator
{
    public class ShipMediumFactory : ShipFactory
    {
        public int _ShipSize;

        public ShipMediumFactory(int shipSize)
        {
            _ShipSize = shipSize;
        }

        public override Ship GetShip()
        {
            return new ShipMedium(_ShipSize);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var obj_new = obj as ShipMediumFactory;

            return obj_new.GetShip().Equals(GetShip());
        }
    }
}
