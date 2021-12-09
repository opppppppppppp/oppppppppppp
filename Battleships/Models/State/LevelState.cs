using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battleships.LevelBuilder;

namespace Battleships.Models.State
{
    public abstract class LevelState
    {
        protected LevelState nextState;

        public abstract ILevelBuilder BuildLevel();

        public LevelState GetNextLevel()
        {
            return nextState;
        }
    }
}
