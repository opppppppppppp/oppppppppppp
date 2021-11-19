using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Composite
{
    public abstract class Component
    {
        public abstract void AddChild(string position);
    }
}
