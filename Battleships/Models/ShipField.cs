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
    public class ShipField
    {
        private static DataTable tabledata { get; set; }
        private static DataGridView table { get; set; }
        public static List<string> positions { get; set; }
        public static int FieldSize { get; set; }

        char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public ShipField(int size, DataGridView tab)
        {
            FieldSize = size;
            positions = new List<string>();
            tabledata = new DataTable();
            table = tab;
            tabledata = GenerateTable();
            table.DataSource = tabledata;
        }

        public DataGridView GetTable()
        {
            return table;
        }
        public DataTable GenerateTable()
        {
            GeneratePositions();
            AddColumns();
            AddRows();
            AddValues();
            return tabledata;
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

        public int GetColumn(int index, int row)
        {
            return index - (row * FieldSize) - 1;
        }

        public int[] GetRowAndColumn(int index)
        {
            int row = GetRow(index);
            int[] RowAndColumn = { row, GetColumn(index, row) };
            return RowAndColumn;
        }

        //public DataGridView MarkShip(int index)
        //{
        //    int row = index / FieldSize;
        //    int column = index - (row * FieldSize) - 1;
        //    table.Rows[row].Cells[column].Style.BackColor = Color.Red;
        //    return table;
        //}
    }
}
