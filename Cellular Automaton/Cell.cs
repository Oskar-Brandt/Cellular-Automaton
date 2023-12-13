using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automaton
{
    public class Cell
    {
        public bool Activated { get; set; }

        public Cell(bool activated = "False") {
            Activated = activated;

        }

        public override string ToString()
        {
            int boolValue;
            if (Activated)
            {
                boolValue = 1;
            }
            else
            {
                boolValue = 0;
            }
            return boolValue.ToString();
        }
    }
}
