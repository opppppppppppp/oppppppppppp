using Battleships.Models.Factory_Method.ConcreteOrangeProduct;
using Battleships.Models.Factory_Method.ConcreteProduct;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class ShipSmallFactory : ShipFactory
    {
        private Dictionary<string, OrangeShip> orange_dict;
        private Dictionary<string, BlueShip> blue_dict;

        private Color _Color;

        public ShipSmallFactory()
        {
            orange_dict = new Dictionary<string, OrangeShip>();
            blue_dict = new Dictionary<string, BlueShip>();
        }

        public override OrangeShip GetOrangeShip()
        {
            string key = "SmallOrange";
            if (!orange_dict.ContainsKey(key)) {
                orange_dict[key] = new SmallOrangeShip();
            }
            return orange_dict[key];
        }

        public override BlueShip GetBlueShip()
        {
            string key = "SmallBlue";
            if (!blue_dict.ContainsKey(key))
            {
                blue_dict[key] = new SmallBlueShip();
            }
            return blue_dict[key];
        }
    }
}
