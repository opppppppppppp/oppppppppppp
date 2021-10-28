using Battleships.LevelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Adapter
{
    interface IPos
    {
        List<int> generatePos(int type, Level level, ShipField PlayerPos);
    }
}
