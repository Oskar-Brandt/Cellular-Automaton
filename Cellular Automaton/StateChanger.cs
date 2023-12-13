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

            return nextState;
        }
    }
}
