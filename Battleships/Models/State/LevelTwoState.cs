using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.LevelBuilder;

namespace Battleships.Models.State
{
    class LevelTwoState : LevelState
    {
        public LevelTwoState(LevelState nextState)
        {
            this.nextState = nextState;
        }

        public LevelTwoState()
        {
            this.nextState = new LevelThreeState();
        }

        public override ILevelBuilder BuildLevel()
        {
            return new LevelTwoBuilder();
        }
    }
}
