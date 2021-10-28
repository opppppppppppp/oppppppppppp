using Battleships.LevelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Adapter
{
    class Pos : IPos
    {
        public List<int> generatePos(int type, Level level, ShipField PlayerPos)
        {
            if(type == 0)
            {
                return new PosAdapter(type).generatePos(type, level, PlayerPos);
            }
            else
            {
                int tblSz = PlayerPos.GetTableSize();
                int shpSz = level.NumberOfShips;
                int stepSz = (tblSz / shpSz) - 1;
                List<int> positions = new List<int>();
                for(int i = 0; i < shpSz; i++)
                {
                    positions.Add((i * stepSz) + 1);
                }
                return positions;
            }
        }
    }
}
