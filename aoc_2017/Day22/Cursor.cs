using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day22
{
    class Cursor
    {
        public enum Direction
        {
            Up = 0,
            Right,
            Down,
            Left
        }

        public enum Doble // spanish for "turn"
        {
            Left = 0,
            Forward,
            Right,
            Reverse
        }

        public Direction Compass { get; set; }
        public Tuple<int, int> Coordinates { get; set; }

        protected Cursor()
        {
            Compass = Direction.Up;
        }

        public Cursor(int origin) : this()
        {
            Coordinates = new Tuple<int, int>(origin, origin);
        }

        public void Turn(Doble doble)
        {
            var numEnums = System.Enum.GetNames(typeof (Direction)).Length;

            switch (doble)
            {
                case Doble.Left:
                    Compass = (Direction)(((int)Compass + numEnums - 1) % numEnums);
                    break;
                case Doble.Forward:
                    break;
                case Doble.Right:
                    Compass = (Direction)(((int)Compass + 1) % numEnums);
                    break;
                case Doble.Reverse:
                    Compass = (Direction)(((int)Compass + numEnums/2) % numEnums); // assumes even number of enum elements
                    break;
                default:
                    throw new Exception("A Turn for the worse!");
            }
        }

        public void Move()
        {
            switch (Compass)
            {
                case Direction.Up:
                    Coordinates = new Tuple<int, int>(Coordinates.Item1, Coordinates.Item2 - 1);
                    break;
                case Direction.Right:
                    Coordinates = new Tuple<int, int>(Coordinates.Item1 + 1, Coordinates.Item2);
                    break;
                case Direction.Down:
                    Coordinates = new Tuple<int, int>(Coordinates.Item1, Coordinates.Item2 + 1);
                    break;
                case Direction.Left:
                    Coordinates = new Tuple<int, int>(Coordinates.Item1 - 1, Coordinates.Item2);
                    break;
                default:
                    throw new Exception("Bad move!");
            }
        }
    }
}
