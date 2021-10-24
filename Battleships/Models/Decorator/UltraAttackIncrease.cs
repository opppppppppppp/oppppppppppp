using Battleships.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Decorator
{
    class UltraAttackIncrease : AttackIncreaseDecorator
    {
        public UltraAttackIncrease(IAttackStrategy aAttack) : base(aAttack)
        {
        }
        public override string Name => base.aAttack.Name;
        public override int shipCount => base.aAttack.shipCount * 3;
        public override List<string> GetAttackingShips(List<string> attackships)
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
