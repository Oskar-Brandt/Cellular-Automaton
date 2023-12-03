using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    internal class CellGrid
    {
        private Cell[,] cells;
        private CellGenerator generator;

        public CellGrid()
        {
            cells = new Cell[10, 10];
            generator = new CellGenerator();
            
            for (int i = 0; i < cells.GetLength(1); i++)
            {
                if (i == 3 || i == 7)
                {
                    cells[0, i] = new Cell(true);
                }
                else
                {
                    cells[0, i] = new Cell(false);
                }
            }
        }

        public void generate()
        {
            for (int i = 0; i < cells.GetLength(0) - 2; i++)
            {
                for(int j = 0; j < cells.GetLength(1); j++)
                {
                    Cell newCell = generator.generateNewCell(cells[i, j], cells, i, j);
                    cells[i + 1, j] = newCell;
                }
                showUpdatedGrid();
            }
        }

        private void showUpdatedGrid()
        {
            Console.WriteLine();
            int i = 0;
            foreach (Cell cell in cells)
            {
                string binary;
                if(cell == null)
                {
                    binary = "0";
                }
                else
                {
                    binary = cell.ToString();
                }

                Console.Write($"| {binary} |");
                i++;
                if (i == 10)
                {
                    Console.WriteLine();
                    i = 0;
                }
            }
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
