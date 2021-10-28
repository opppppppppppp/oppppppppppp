using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships.Models.Bridge
{
    public enum CellState
    {
        Ship,
        Hit,
        NotHitBlue,
        NotHitOrange,
        NotHit
    }

    public interface ShipFieldUpgradeInterface
    {
        void upgrade(DataGridView table, int row, int column, CellState state);
    }
}
