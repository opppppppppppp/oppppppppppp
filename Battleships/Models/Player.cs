using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    class Player
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public Player(string name, int id)
        {
            Name = name;
            ID = id;
        }
    }
}
