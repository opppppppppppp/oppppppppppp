using Battleships.LevelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Adapter
{
    public class PosAdapter : IPos
    {
        private IPosGenerator posGenerator;

        public PosAdapter(int type)
        {
            if(type == 0)
            {
                posGenerator = new RandomPosGenerator();
            }
        }

        public List<int> generatePos(int type, Level level, ShipField PlayerPos)
        {
            if (type == 0)
            {
                return posGenerator.generatePos(level.NumberOfShips, PlayerPos.GetTableSize());
            }
            else return null;
        }
    }
}
