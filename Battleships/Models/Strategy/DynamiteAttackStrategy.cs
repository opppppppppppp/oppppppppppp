using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships.Models.Strategy
{
    public class DynamiteAttackStrategy : IAttackStrategy
    {
        public virtual string Name => nameof(DynamiteAttackStrategy);
        public virtual int shipCount => 2;
        public virtual List<string> GetAttackingShips(List<string> attackships)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<string> generated_ships = new List<string>();
            while (generated_ships.Count != shipCount)
            {
                int number = rnd.Next(1, attackships.Count);
                string ship = attackships[number];
                if (!generated_ships.Contains(ship))
                {
                    generated_ships.Add(ship);
                }
            }
            return generated_ships;
        }
    }
}
