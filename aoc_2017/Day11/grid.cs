using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day11
{
    class Grid
    {
        public enum Direction
        {
            N = 0,
            NE,
            SE,
            S,
            SW,
            NW
        }

        //private HashSet<Hex> Hexes { get; set; }

        private Hex Origin { get; set; }
        private Hex Current { get; set; }

        public Grid()
        {
            // fill with the origin
            Current = Origin = new Hex() { Q = 0, R = 0 };
            //Hexes = new HashSet<Hex> { Origin };
        }

        public void Step(Direction direction)
        {
            var q = 0;
            var r = 0;

            switch (direction)
            {
                case Direction.N:
                    q = 0;
                    r = -1;
                    break;
                case Direction.NE:
                    q = 1;
                    r = -1;
                    break;
                case Direction.SE:
                    q = 1;
                    r = -0;
                    break;
                case Direction.S:
                    q = 0;
                    r = 1;
                    break;
                case Direction.SW:
                    q = -1;
                    r = 1;
                    break;
                case Direction.NW:
                    q = -1;
                    r = 0;
                    break;
                default:
                    throw new Exception("Unsupported step direction!");
            }

            Current = Current.Step(q, r);
            //Hexes.Add(Current);
        }

        // returns the distance between the origin and the current hex
        // axial hex distance is derived from the Manhattan distance on cubes
        public int OriginToCurrent()
        {
            var a = Origin;
            var b = Current;
            return (Math.Abs(a.Q - b.Q)
                  + Math.Abs(a.Q = a.R - b.Q - b.R)
                  + Math.Abs(a.R - b.R)) / 2;
        }
    }
}
