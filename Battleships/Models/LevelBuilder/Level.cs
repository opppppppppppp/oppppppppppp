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
        public virtual int NumberOfShips { get; set; }
        public ShipFactory ShipFactory { get; set; }
        public string Title { get; set; }
        public IAttackStrategy Strategy { get; set; }
        public IAttackStrategy IncreasedStrategy { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Level level = obj as Level;
            return (NumberOfShips == level.NumberOfShips && Title == level.Title && ShipFactory.GetType() == level.ShipFactory.GetType() &&
                Strategy.GetType() == level.Strategy.GetType() && IncreasedStrategy.GetType() == level.IncreasedStrategy.GetType());
        }

    }
}
