using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships.Models.Bridge
{
    public class ShipFieldUpgradeGood : ShipFieldUpgradeInterface
    {
        public void upgrade(DataGridView table, int row, int column, CellState state)
        {

            if (state == CellState.NotHitOrange)
            {
                table.Rows[row].Cells[column].Style.BackColor = Color.Orange;
            }
            else if (state == CellState.Hit)
            {
                table.Rows[row].Cells[column].Style.BackColor = Color.Red;
            }
            else if (state == CellState.Ship)
            {
                table.Rows[row].Cells[column].Style.BackColor = Color.Pink;
            } 
            else if (state == CellState.NotHitBlue)
            {
                table.Rows[row].Cells[column].Style.BackColor = Color.LightBlue;
            }
            else if (state == CellState.NotHit)
            {
                table.Rows[row].Cells[column].Style.BackColor = Color.Yellow;
            }
        }
    }
}
