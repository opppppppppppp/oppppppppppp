using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Composite
{
    public abstract class FileSystem
    {
        public string Name { get; }

        public FileSystem(string name)
        {
            this.Name = name;
        }
        
    }
}
