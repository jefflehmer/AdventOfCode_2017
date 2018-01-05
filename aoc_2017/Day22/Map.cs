using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day22
{
    class Map
    {
        private HashSet< Tuple<int, int> > Infected { get; set; }
        public int Infections { get; set; }

        private Direction Compass { get; set; }
        private enum Direction
        {
            Up = 0,
            Right,
            Down,
            Left
        }

        protected Tuple<int, int> Carrier { get; set; }

        public Map(string[] lines)
        {
            Infected = new HashSet< Tuple<int, int> >();
            Infections = 0;
            Compass = Direction.Up;
            Carrier = new Tuple<int, int> (lines.Length / 2, lines.Length / 2);

            InitializeInfection(lines);
        }

        private void InitializeInfection(string[] lines)
        {
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                var chars = line.ToCharArray();
                for (var x = 0; x < lines.Length; x++)
                {
                    if (chars[x] == '#')
                        Infected.Add(new Tuple<int, int>(x, y));
                }
            }
        }

        public void Burst()
        {
            Turn();
            Cleanfect();
            Move();
        }

        private void Turn()
        {
            var infected = Infected.Contains(Carrier);
            switch (Compass)
            {
                case Direction.Up:
                    Compass = infected ? Direction.Right : Direction.Left;
                    break;
                case Direction.Right:
                    Compass = infected ? Direction.Down : Direction.Up;
                    break;
                case Direction.Down:
                    Compass = infected ? Direction.Left : Direction.Right;
                    break;
                case Direction.Left:
                    Compass = infected ? Direction.Up : Direction.Down;
                    break;
                default:
                    throw new Exception("Bad directions!");
            }
        }

        private void Cleanfect()
        {
            if (Infected.Contains(Carrier))
            {
                Infected.Remove(Carrier);
            }
            else
            {
                Infections++;
                Infected.Add(Carrier);
            }
        }

        private void Move()
        {
            switch (Compass)
            {
                case Direction.Up:
                    Carrier = new Tuple<int, int>(Carrier.Item1, Carrier.Item2 - 1);
                    break;
                case Direction.Right:
                    Carrier = new Tuple<int, int>(Carrier.Item1 + 1, Carrier.Item2);
                    break;
                case Direction.Down:
                    Carrier = new Tuple<int, int>(Carrier.Item1, Carrier.Item2 + 1);
                    break;
                case Direction.Left:
                    Carrier = new Tuple<int, int>(Carrier.Item1 - 1, Carrier.Item2);
                    break;
                default:
                    throw new Exception("Bad move!");
            }
        }
    }
}
