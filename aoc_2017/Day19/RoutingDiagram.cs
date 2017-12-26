using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day19
{
    class RoutingDiagram
    {
        #region fields, constants, properties, and ctors
        public string[] Paths { get; set; } // each entry is another row/Y-coordinate

        private int X { get; set; } // offset into the x direction
        private int Y { get; set; } // offset into the y direction
        private int Width { get; set; }

        private const char DeadEnd = ' ';
        private StringBuilder _letters;
        public string Letters => _letters.ToString();
        public int Steps { get; set; }

        private Direction Compass { get; set; }

        private enum Direction
        {
            Up = 0,
            Right,
            Down,
            Left
        }

        private bool InBounds => (X >= 0) && (X < Width) && (Y >= 0) && (Y < Paths.Length);

        public RoutingDiagram()
        {
            X = Y = 0;
        }
        #endregion fields, constants, properties, and ctors

        public bool TracePath()
        {
            InitializeDiagramStart();

            do
            {
                if (Next() == DeadEnd)
                    return false;
            } while (InBounds);

            return true;
        }

        private void InitializeDiagramStart()
        {
            var x = 0;
            var firstRow = Paths[0];
            for (x = 0; x < firstRow.Length; x++)
            {
                if (firstRow[x] == '|')
                    break;
            }
            X = x;
            Y = 0;
            Width = firstRow.Length;
            Compass = Direction.Down;
            _letters = new StringBuilder();
            Steps = 0;
        }

        private char Next()
        {
            var next = DeadEnd;

            // adjust your X & Y coordinates
            switch (Compass)
            {
                case Direction.Up:
                    next = Paths[--Y][X];
                    break;
                case Direction.Right:
                    next = Paths[Y][++X];
                    break;
                case Direction.Down:
                    next = Paths[++Y][X];
                    break;
                case Direction.Left:
                    next = Paths[Y][--X];
                    break;
            }

            switch (next)
            {
                case '|':
                case '-':
                    break;
                case '+':
                    if (Compass == Direction.Up || Compass == Direction.Down)
                    {
                        Compass = Paths[Y][X - 1] == DeadEnd ? Direction.Right : Direction.Left;
                    }
                    else if (Compass == Direction.Left || Compass == Direction.Right)
                    {
                        Compass = Paths[Y - 1][X] == DeadEnd ? Direction.Down : Direction.Up;
                    }
                    break;
                case ' ': // do nothing.  the handler will decide.
                    break;
                default: // must be a letter
                    _letters.Append(next);
                    break;
            }

            Steps++;
            return next;
        }
    }
}
