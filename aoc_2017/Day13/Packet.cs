using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day13
{
    class Packet
    {
        public int CurrentDepth { get; set; }
        public Layer CurrentLayer { get; set; }

        public int Next(int depth, Layer nextLayer, out bool caught)
        {
            int severity = 0;
            caught = false;

            CurrentDepth = depth;
            if (nextLayer != null)
            {
                // caught?
                if (nextLayer.Caught())
                {
                    severity = nextLayer.Depth * nextLayer.Range;
                    caught = true;
                }

                CurrentLayer = nextLayer;
            }

            return severity;
        }
    }
}
