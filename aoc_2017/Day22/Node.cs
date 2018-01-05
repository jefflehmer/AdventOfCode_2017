using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day22
{
    class Node
    {
        public enum State
        {
            Clean,
            Weakened,
            Infected,
            Flagged
        }

        public State Status { get; set; }
        public Node()
        {
            Status = State.Clean;
        }

        public State UpdateStatus()
        {
            switch (Status)
            {
                case State.Clean:
                    Status = State.Weakened;
                    break;
                case State.Weakened:
                    Status = State.Infected;
                    break;
                case State.Infected:
                    Status = State.Flagged;
                    break;
                case State.Flagged:
                    Status = State.Clean;
                    break;
                default:
                    throw new Exception("Status Incognito!");
            }
            return Status;
        }
    }
}
