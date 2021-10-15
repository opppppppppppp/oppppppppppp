using Battleships.Models;
using Battleships.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.LevelBuilder
{
    public class Level
    {
        public int NumberOfShips { get; set; }
        public ShipFactory ShipFactory { get; set; }
        public string Title { get; set; }
        public IAttackStrategy Strategy { get; set; }
        public IAttackStrategy IncreasedStrategy { get; set; }

    }
}
