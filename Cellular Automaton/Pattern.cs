using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class Pattern
    {
        public bool AbovePos { get; set; }
        public bool LeftPos { get; set; }
        public bool TargetPos { get; set; }
        public bool RightPos { get; set; }
        public bool BelowPos { get; set; }

        public Pattern(bool abovePos, bool leftPos, bool targetPos, bool rightPos, bool belowPos)
        {
            AbovePos = abovePos;
            LeftPos = leftPos;
            TargetPos = targetPos;
            RightPos = rightPos;
            BelowPos = belowPos;

        }
    }
}

        
