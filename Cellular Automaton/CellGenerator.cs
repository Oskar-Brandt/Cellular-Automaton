using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class CellGenerator
    {
        private Pattern[] patterns;

        public CellGenerator()
        {
            patterns = new Pattern[8];

            patterns[0] = new Pattern(false, false, false, false);
            patterns[1] = new Pattern(false, false, true, true);
            patterns[2] = new Pattern(false, true, false, false);
            patterns[3] = new Pattern(false, true, true, false);
            patterns[4] = new Pattern(true, false, false, true);
            patterns[5] = new Pattern(true, false, true, true);
            patterns[6] = new Pattern(true, true, false, false);
            patterns[7] = new Pattern(true, true, true, false);

        }

        public Cell generateNewCell(Cell cell, Cell[,] cells, int row, int col)
        {
            Cell targetCell = cell;

            Cell leftCell;
            Cell rightCell;
            

            if (col == 0)
            {
                leftCell = cells[row,9];
            }
            else
            {
                leftCell = cells[row,col - 1];
            }

            if (col == cells.GetLength(1) - 1)
            {
                rightCell = cells[row,0];
            }
            else
            {
                rightCell = cells[row,col + 1];
            }


            Pattern currentCellPattern = new Pattern(leftCell.Activated, targetCell.Activated, rightCell.Activated);

            foreach (Pattern pattern in patterns)
            {
                if (patternMatch(pattern, currentCellPattern))
                {
                    return new Cell(pattern.NewCellActivated);
                }
            }

            Console.WriteLine("No pattern was found!");
            return null;

        }

        private bool patternMatch(Pattern pattern, Pattern currentPattern)
        {
            if (pattern.LeftPos == currentPattern.LeftPos && pattern.TargetPos == currentPattern.TargetPos && pattern.RightPos == currentPattern.RightPos)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
