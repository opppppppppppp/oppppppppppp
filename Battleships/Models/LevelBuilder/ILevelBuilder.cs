using Battleships.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.LevelBuilder
{
    public interface ILevelBuilder
    {
        void SetTitle();
        void SetNumberOfShips();
        void SetStrategy();
        void IncreasedStrategy();
        Level GetLevel();
    }
}
