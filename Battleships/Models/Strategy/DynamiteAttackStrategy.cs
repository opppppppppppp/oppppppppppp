﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships.Models.Strategy
{
    class DynamiteAttackStrategy : IAttackStrategy
    {
        public string Name => nameof(DynamiteAttackStrategy);

        public int shipCount => 2;
        public List<Button> GetAttackingShips(List<Button> attackships)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            List<Button> generated_ships = new List<Button>();
            while (generated_ships.Count != shipCount)
            {
                int number = rnd.Next(1, attackships.Count);
                Button ship = attackships[number];
                if (!generated_ships.Contains(ship))
                {
                    generated_ships.Add(ship);
                }
            }
            return generated_ships;
        }
    }
}