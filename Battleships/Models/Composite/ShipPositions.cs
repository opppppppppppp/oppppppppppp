using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Composite
{
    public class ShipPositions : Component
    {
        public List<string> positions;
        public ShipPositions()
        {
            positions = new List<string>();
        }
        public override void AddChild(string position)
        {
            positions.Add(position);
        }
        public void RemoveChild(string position)
        {
            positions.Remove(position);
        }
        public string GetChild(int index)
        {
            return positions[index];
        }
    }
}
