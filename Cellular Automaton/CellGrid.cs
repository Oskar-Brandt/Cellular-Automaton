using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class CellGrid
    {
        private Cell[,] cells;
        private CellGenerator generator;
        public List<State> states;

        public CellGrid()
        {
            cells = new Cell[10, 10];
            generator = new CellGenerator();
            states = new List<State>();
        }

        public List<State> generate()
        {
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
            saveState();

            for (int i = 0; i < cells.GetLength(0) - 1; i++)
            {
                for(int j = 0; j < cells.GetLength(1); j++)
                {
                    Cell newCell = generator.generateNewCell(cells[i, j], cells, i, j);
                    cells[i + 1, j] = newCell;
                }
                saveState();
                //showUpdatedGrid();
            }
            List<State> currentStates = states;
            return currentStates;
        }

        private void saveState()
        {
            State currentState = new State(cells);
            states.Add(currentState);
        }
    }
}
