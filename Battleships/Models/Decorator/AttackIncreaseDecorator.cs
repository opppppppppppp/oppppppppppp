using Battleships.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Decorator
{
    public class AttackIncreaseDecorator : IAttackStrategy
    {
        public IAttackStrategy aAttack;
        public AttackIncreaseDecorator(IAttackStrategy aAttack)
        {
            this.aAttack = aAttack;
        }
        public virtual string Name => this.aAttack.Name;
        public virtual int shipCount => this.aAttack.shipCount;
        public virtual List<string> GetAttackingShips(List<string> attackships)
        {
            return this.aAttack.GetAttackingShips(attackships);
        }

    }
}
