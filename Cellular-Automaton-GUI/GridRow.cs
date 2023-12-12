using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cellular_Automaton;

namespace Cellular_Automaton_GUI
{
    class GridRow
    {
        Cell[] CellsInRow { get; set; }

        public GridRow(int currentRow, Cell[,] cells)
        {
            int cols = cells.GetLength(1);
            CellsInRow = new Cell[cols];
            
            for (int i = 0; i < cols; i++)
            {
                Cell cell = cells[currentRow, i];
                CellsInRow[i] = cell;
            }
        }
    }
}
