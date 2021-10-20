using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Adapter
{
    class PosAdapter : IPos
    {
        private IPosGenerator posGenerator;

        public PosAdapter(int type)
        {
            if(type == 0)
            {
                posGenerator = new RandomPosGenerator();
            }
        }

        public List<int> generatePos(int type, ShipFactory Ships, ShipField PlayerPos)
        {
            if (type == 0)
            {
                return posGenerator.generatePos(Ships.GetShip().ShipSize, PlayerPos.GetTableSize());
            }
            else return null;
        }
    }
}
