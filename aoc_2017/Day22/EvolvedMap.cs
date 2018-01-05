using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day22
{
    class EvolvedMap
    {
        private Dictionary< Tuple<int, int>, Node > Infected { get; set; }
        public int Infections { get; set; }

        protected Cursor Carrier { get; set; }

        public EvolvedMap(string[] lines)
        {
            Infected = new Dictionary< Tuple<int, int>, Node >();
            Infections = 0;
            Carrier = new Cursor(lines.Length / 2);

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
                        Infected.Add(new Tuple<int, int>(x, y), new Node { Status = Node.State.Infected });
                }
            }
        }

        public void Burst()
        {
            Turn();
            Cleanfect();
            Carrier.Move();
        }

        private void Turn()
        {
            var node = GetCurrentNode();//first after first turn&move this should be infected 
            var nodeStatus = node?.Status ?? Node.State.Clean;

            switch (nodeStatus)
            {
                case Node.State.Clean:
                    Carrier.Turn(Cursor.Doble.Left);
                    break;
                case Node.State.Weakened:
                    Carrier.Turn(Cursor.Doble.Forward); // redundant
                    break;
                case Node.State.Infected:
                    Carrier.Turn(Cursor.Doble.Right);
                    break;
                case Node.State.Flagged:
                    Carrier.Turn(Cursor.Doble.Reverse);
                    break;
                default:
                    throw new Exception("Bad directions!");
            }
        }

        private void Cleanfect()
        {
            var status = Node.State.Weakened;
            var node = GetCurrentNode();
            if (node != null)
                status = node.UpdateStatus();
            else
                Infected.Add(Carrier.Coordinates, new Node { Status = status });

            if (status == Node.State.Clean)
                Infected.Remove(Carrier.Coordinates);
            else if (status == Node.State.Infected)
                Infections++;
        }

        private Node GetCurrentNode()
        {
            return Infected.ContainsKey(Carrier.Coordinates) ? Infected[Carrier.Coordinates] : null;
        }
    }
}
