using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Adapter
{
    interface IPosGenerator
    {
        List<int> generatePos(int shipSize, int tableSize);
    }
}
