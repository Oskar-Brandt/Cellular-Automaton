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
        public List<State> states; //Used to display the number of states completed
        public State currentState { get; set; } //This may be used to display the cells, instead of using the Cells 2d array each time

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
            }
            List<State> currentStates = states;
            return currentStates;
        }

        private void saveState()
        {
            State currentState = new State(Cells);
            states.Add(currentState);
        }


        private void generateCells(int gridWidth, int gridHeight)
        {
            //A method to call during construction
            //
            //Should initialize and construct all cells to be used in the grid.
            //Activation status of the cells will then be set some other place.
        }

        private State setInitialActivations(int cellsActivated)
        {
            State initState = null;
            //A method to call during construction, after cells have been generated
            //
            //Sets the initial state of the grid, or rather, which cells start out being activated
            //May be determined randomly, though a number can be passed to the param to note how many cells should be activated
            return initState;
        }

        public State generateNextState()
        {
            State nextState = null;

            //A method for MainWindow to call to make the next state of the grid
            //
            //Should be called each time a new state is needed for the grid
            //Should check every cell, and change its activation status if needed
            //Should probably use CellGenerator (Or a new class), which then uses some kind of pattern (New class may be needed for this too)

            return nextState;
        }

    }
}
