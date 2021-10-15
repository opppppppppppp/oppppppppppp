﻿using Battleships.Models.Strategy;
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
            return base.aAttack.GetAttackingShips(attackships);
        }
    }
}
