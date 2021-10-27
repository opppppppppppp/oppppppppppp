using Battleships.Models.Bridge;
using Battleships.Models.Prototype;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleships.Models
{
    public class ShipField : ShipFieldPrototype
    {
        private DataTable tabledata { get; set; }
        private DataGridView table { get; set; }
        public List<string> positions { get; set; }
        public int FieldSize { get; set; }
        public int DestroyedShips { get; set; }

        private ShipFieldUpgradeInterface shipFieldUpgradeInterface;

        char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public ShipField(int size, DataGridView table, ShipFieldUpgradeInterface shipFieldUpgradeInterface)
        {
            DestroyedShips = 0;
            FieldSize = size;
            positions = new List<string>();
            tabledata = new DataTable();
            this.table = table;
            tabledata = GenerateTable();
            table.DataSource = tabledata;
            this.shipFieldUpgradeInterface = shipFieldUpgradeInterface;
        }

        public override ShipFieldPrototype Clone()
        {
            Console.WriteLine("Cloned ShipField");
            return this.MemberwiseClone() as ShipFieldPrototype;
        }
        public DataTable GetTableData()
        {
            return tabledata;
        }
        public DataTable GenerateTable()
        {
            GeneratePositions();
            AddColumns();
            AddRows();
            AddValues();
            return tabledata;
        }
        public void SetTable(DataGridView table)
        {
            this.table = table;
        }
        public List<string> GetPositions()
        {
            return positions;
        }
        public int GetTableSize()
        {
            return FieldSize * FieldSize;
        }
        private void AddColumns()
        {
            for (int i = 0; i < FieldSize; i++)
            {
                tabledata.Columns.Add((i+1).ToString());
            }
        }
        private void AddRows()
        {
            for (int i = 0; i < FieldSize; i++)
            {
                DataRow table_row = tabledata.NewRow();
                tabledata.Rows.Add(table_row);
            }
        }
        private void AddValues()
        {
            for(int i = 0;i<FieldSize;i++)
            {
                DataRow table_row = tabledata.Rows[i];
                for (int j = 0;j<FieldSize;j++)
                {
                    table_row[j] = positions[i*FieldSize + j];
                }
            }
        }
        private void GeneratePositions()
        {
            int letter_index = 0;
            int index = 1;
            for (int i = 0;i<FieldSize * FieldSize;i++)
            {
                if (i % FieldSize == 0 && i != 0)
                {
                    letter_index++;
                    index = 1;
                }
                positions.Add(letters[letter_index] + (index).ToString());
                index++;
            }
        }
        public int GetRow(int index)
        {
            return index / FieldSize;
        }
        public int GetColumn(int index)
        {
            return index - (GetRow(index) * FieldSize);
        }
        public int GetShipIndex(string ship)
        {
            return positions.IndexOf(ship);
        }

        public string GetShipValue(int index)
        {
            int row = GetRow(index);
            int column = GetColumn(index);
            return table.Rows[row].Cells[column].Value.ToString();
        }
        public void MarkHitShip(int index)
        {
            int row = GetRow(index);
            int column = GetColumn(index);
            table.Rows[row].Cells[column].Value = "O";
            shipFieldUpgradeInterface.upgrade(table, row, column, CellState.NotHit);
        }

        public void MarkDestroyedShip(int index)
        {
            int row = GetRow(index);
            int column = GetColumn(index);
            table.Rows[row].Cells[column].Value = "X";
            DestroyedShips++;
            shipFieldUpgradeInterface.upgrade(table, row, column, CellState.Hit);
        }

        public void MarkShip(int index)
        {
            int row = GetRow(index);
            int column = GetColumn(index);
            table.Rows[row].Cells[column].Value = "S";
            shipFieldUpgradeInterface.upgrade(table, row, column, CellState.Ship);
        }

        public void updateShipFieldUpgradeInterface(ShipFieldUpgradeInterface shipFieldUpgradeInterface)
        {
            this.shipFieldUpgradeInterface = shipFieldUpgradeInterface;
        }

    }
}
