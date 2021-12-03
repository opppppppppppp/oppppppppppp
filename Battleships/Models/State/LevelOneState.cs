using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.LevelBuilder;

namespace Battleships.Models.State
{
    class LevelOneState : LevelState
    {
        public LevelOneState(LevelState nextState)
        {
            this.nextState = nextState;
        }

        public LevelOneState()
        {
            this.nextState = new LevelTwoState();
        }

        public override ILevelBuilder BuildLevel()
        {
            return new LevelOneBuilder();
        }
    }
}
