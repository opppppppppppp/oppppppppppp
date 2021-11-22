using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Adapter
{
    public class RandomPosGenerator : IPosGenerator
    {
        public List<int> generatePos(int shipSize, int tableSize)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<int> positions = new List<int>();
            while (positions.Count != shipSize)
            {
                int number = rnd.Next(1, tableSize - 1);
                if (!positions.Contains(number))
                {
                    positions.Add(number);
                }
            }
            return positions;
        }
    }
}
