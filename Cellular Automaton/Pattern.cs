using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class Pattern
    {
        public bool LeftPos { get; set; }
        public bool TargetPos { get; set; }
        public bool RightPos { get; set; }
        public bool NewCellActivated { get; set; }

        public Pattern(bool leftPos, bool targetPos, bool rightPos, bool newCellActivated = false)
        {
            LeftPos = leftPos;
            TargetPos = targetPos;
            RightPos = rightPos;
            NewCellActivated = newCellActivated;

        }
    }
}

        
