using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day_3
{
    class Manhattan
    {
        internal enum SENW
        {
            South = 0,
            East,
            North,
            West
        }

        public SENW Direction { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int bottom { get; set; }
        public int right { get; set; }
        public int top { get; set; }
        public int left { get; set; }
        public bool turn { get; set; }

        public Manhattan(int steps)
        {
            Direction = SENW.South;
            x = y = bottom = right = top = left = 0;
            turn = true;
        }

        public void Walk(int steps)
        {
            for (int i = 1; i < steps; i++)
            {
                SetDirection(i);
                Move(i);
            }
        }

        private void SetDirection(int idx)
        {
            // change direction if you can turn move
            switch (Direction)
            {
                case SENW.South:
                    if (turn)
                        Direction = SENW.East;
                    break;

                case SENW.East:
                    if (turn)
                        Direction = SENW.North;
                    break;

                case SENW.North:
                    if (turn)
                        Direction = SENW.West;
                    break;

                case SENW.West:
                    if (turn)
                        Direction = SENW.South;
                    break;
            }
            turn = false;
        }

        private void Move(int idx)
        {
            switch (Direction)
            {
                case SENW.South:
                    y -= 1;
                    if (y < bottom)
                    {
                        bottom = y;
                        turn = true;
                    }
                    break;

                case SENW.East:
                    x += 1;
                    if (x > right)
                    {
                        right = x;
                        turn = true;
                    }
                    break;

                case SENW.North:
                    y += 1;
                    if (y > top)
                    {
                        top = y;
                        turn = true;
                    }
                    break;

                case SENW.West:
                    x -= 1;
                    if (x < left)
                    {
                        left = x;
                        turn = true;
                    }
                    break;
            }
        }

        public int CalculateDistance()
        {
            return Math.Abs(x) + Math.Abs(y);
        }

    }
}
