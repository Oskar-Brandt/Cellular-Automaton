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
                
                int row = rand.Next(0, cells.GetLength(0));
                int col = rand.Next(0, cells.GetLength(1));

                while (cells[row, col].Activated)
                {
                    row = rand.Next(0, cells.GetLength(0));
                    col = rand.Next(0, cells.GetLength(1));
                }
                cells[row, col].Activated = true;
            }
            initState = new State(cells);

            return initState;
        }

        public State generateNextState(State currentState)
        {
            State nextState = new State(currentState.Cells);

            Cell[,] currentCells = currentState.Cells;
            Cell[,] nextStateCells = nextState.Cells;

            
            

            for(int i = 0; i < currentCells.GetLength(0);i++)
            {
                for(int j = 0; j < currentCells.GetLength(1); j++)
                {
                    bool isCurrentCellActive = currentCells[i,j].Activated;
                    int activeNeighbours = 0;

                    if (i != 0)
                    {
                        if (currentCells[i - 1, j].Activated)
                        {
                            activeNeighbours++;
                        }

                        if (j != 0)
                        {
                            if (currentCells[i - 1, j - 1].Activated)
                            {
                                activeNeighbours++;
                            }
                        }

                        if (j != currentCells.GetLength(1) - 1)
                        {
                            if (currentCells[i - 1, j + 1].Activated)
                            {
                                activeNeighbours++;
                            }
                        }

                    }




                    if(i != currentCells.GetLength(0) - 1)
                    {
                        if (currentCells[i + 1, j].Activated)
                        {
                            activeNeighbours++;
                        }

                        if (j != 0)
                        {
                            if (currentCells[i + 1, j - 1].Activated)
                            {
                                activeNeighbours++;
                            }
                        }

                        if (j != currentCells.GetLength(1) - 1)
                        {
                            if (currentCells[i + 1, j + 1].Activated)
                            {
                                activeNeighbours++;
                            }
                        }
                    }


                    if(j != 0)
                    {
                        if (currentCells[i, j - 1].Activated)
                        {
                            activeNeighbours++;
                        }


                    }



                    if(j != currentCells.GetLength(1) - 1)
                    {
                        if (currentCells[i, j + 1].Activated)
                        {
                            activeNeighbours++;
                        }
                    }

                    bool currentCellNextState = patternChecker(isCurrentCellActive, activeNeighbours);

                    nextStateCells[i, j].Activated = currentCellNextState;
                }
            }

            return nextState;
        }

        public bool patternChecker(bool isCellActive, int activeNeighbours)
        {
            if (isCellActive)
            {
                if (activeNeighbours < 2)
                {
                    return false;
                }

                if (activeNeighbours <= 3)
                {
                    return true;
                }

                if(activeNeighbours > 3)
                {
                    return false;
                }
            }

            else if (activeNeighbours == 3)
            {
                return true;
            }

            return false;
            
        }
    }
}
