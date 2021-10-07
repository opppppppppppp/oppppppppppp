using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships.Models.Strategy
{
    public interface IAttackStrategy
    {
        string Name { get; }
        int shipCount { get;}
        List<Button> GetAttackingShips(List<Button> attackships);
    }
}
