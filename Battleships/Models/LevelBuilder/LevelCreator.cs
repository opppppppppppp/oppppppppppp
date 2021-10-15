using Battleships.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.LevelBuilder
{
    public class LevelCreator
    {

        private ILevelBuilder _levelBuilder;
        public LevelCreator(ILevelBuilder levelBuilder)
        {
            _levelBuilder = levelBuilder;
        }
        public void CreateLevel()
        {
                    _levelBuilder.SetTitle();
                    _levelBuilder.SetNumberOfShips();
                    _levelBuilder.SetStrategy();
                    _levelBuilder.IncreasedStrategy();
        }
        public Level GetLevel()
        {
            return _levelBuilder.GetLevel();
        }
    }
}
