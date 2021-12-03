using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.LevelBuilder;

namespace Battleships.Models.State
{
    class LevelThreeState : LevelState
    {
        public LevelThreeState(LevelState nextState)
        {
            this.nextState = nextState;
        }

        public LevelThreeState()
        {
            this.nextState = new LevelOneState();
        }

        public override ILevelBuilder BuildLevel()
        {
            return new LevelThreeBuilder();
        }
    }
}
