using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Iterator
{
    public interface IContainer
    {
        IIterator GetIterator();
    }
    public interface IIterator
    {
        bool HasNext();
        string Next();
    }

    class SpecialAttackRepository : IContainer
    {
        private List<string> attackships;

        public SpecialAttackRepository(List<string> attackships)
        {
            this.attackships = attackships;
        }
        public IIterator GetIterator()
        {
            return new SpecialAttackIterator(attackships);
        }

        class SpecialAttackIterator : IIterator
        {
            private List<string> attackships;
            private int index = 0;

            public SpecialAttackIterator(List<string> attackships)
            {
                this.attackships = attackships;
            }

            public bool HasNext()
            {
                return index < attackships.Count;
            }

            public string Next()
            {
                if (HasNext())
                {
                    return attackships[index++];
                }
                return null;
            }
        }
    }
}
