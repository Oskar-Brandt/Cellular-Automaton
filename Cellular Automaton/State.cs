using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class State
    {
        public Cell[,] Cells { get; set; }

        public State(Cell[,] currentCells)
        {
            try
            {
                Object cells = currentCells.Clone();
                Cells = (Cell[,])cells;
            }
            catch { }
            
        }
    }
}
