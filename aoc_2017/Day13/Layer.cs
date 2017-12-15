using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day13
{
    class Layer
    {
        public int Depth { get; set; }
        public int Range { get; set; }
        public int Scanner { get; set; }

        private bool Up { get; set; }

        public Layer()
        {
            Up = false;
        }
        public void Advance()
        {
            if (!Up && (Scanner + 1) == Range)
                Up = true;
            else if (Up && (Scanner == 0))
                Up = false;
            if (Up) // decrement
                Scanner--;
            else // increment
                Scanner++;
        }

        public bool Caught()
        {
            return Scanner == 0;
        }

        public void Reset()
        {
            Scanner = 0;
            Up = false;
        }
    }
}
