using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day11
{
    // flat-topped, hexagonal grid that uses axial coordinates
    // thx to https://www.redblobgames.com/grids/hexagons/
    class Hex
    {
        public int Q { get; set; } // axis x <--> column
        public int R { get; set; } // axis z <--> row

/*
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
*/

        internal Hex Step(int q, int r)
        {
            return new Hex() {Q = this.Q + q, R = this.R + r};
        }
    }
}
