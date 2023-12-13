using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class StateChanger
    {
        public StateChanger()
        {

        }

        public State setInitialState(Cell[,] cells, int cellsActivated)
        {
            State initState;
            Random rand = new Random();

            for (int i = 0; i < cellsActivated; i++)
            {
                
                int row = rand.Next(0, 10);
                int col = rand.Next(0, 10);

                while (cells[row, col].Activated)
                {
                    row = rand.Next(0, 10);
                    col = rand.Next(0, 10);
                }
                cells[row, col].Activated = true;
            }
            initState = new State(cells);

            return initState;
        }

        public State generateNextState(State currentState)
        {
            State nextState = null;
            Cell[,] cells = currentState.Cells;
            int liveNeighbours = 0;
            

            for(int i = 0; i < cells.GetLength(0);i++)
            {
                for(int j = 0; j < cells.GetLength(1); j++)
                {
                    bool isCurrentCellActive = cells[i,j].Activated;

                    if(i != 0)
                    {
                        if (cells[i - 1, j].Activated)
                        {
                            liveNeighbours++;
                        }
                    }

                    if(i != cells.)

                }
            }


            return nextState;
        }
    }
}
