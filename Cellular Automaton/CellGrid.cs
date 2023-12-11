using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class CellGrid
    {
        public Cell[,] Cells { get; set; }
        private CellGenerator generator;
        public List<State> states;

        public CellGrid()
        {
            Cells = new Cell[10, 10];
            generator = new CellGenerator();
            states = new List<State>();
        }

        public List<State> generate()
        {
            for (int i = 0; i < Cells.GetLength(1); i++)
            {
                if (i == 3 || i == 7)
                {
                    Cells[0, i] = new Cell(true);
                }
                else
                {
                    Cells[0, i] = new Cell(false);
                }
            }
            saveState();

            for (int i = 0; i < Cells.GetLength(0) - 1; i++)
            {
                for(int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cell newCell = generator.generateNewCell(Cells[i, j], Cells, i, j);
                    Cells[i + 1, j] = newCell;
                }
                saveState();
                //showUpdatedGrid();
            }
            List<State> currentStates = states;
            return currentStates;
        }

        private void saveState()
        {
            State currentState = new State(Cells);
            states.Add(currentState);
        }
    }
}
