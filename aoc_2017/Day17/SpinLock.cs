using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day17
{
    class SpinLock
    {
        private LinkedListNode<int> CurrentNode { get; set; }

        public LinkedList<int> List { get; set; }
        //int NumSteps = 3; // test
        int NumSteps = 337; // actual

        // returns the value immediately _after_ the current position
        public int After => Next().Value;
        public int AfterFirst => List.First.Next.Value;

        public SpinLock()
        {
            List = new LinkedList<int>();
            CurrentNode = List.AddFirst(0);
        }

        internal void Insert(int i)
        {
            CurrentNode = Advance().AddAfter(CurrentNode, i);
        }

        internal LinkedList<int> Advance()
        {
            for (var j = 0; j < NumSteps; j++)
                CurrentNode = Next();

            return List;
        }

        private LinkedListNode<int> Next()
        {
            return CurrentNode == List.Last ? List.First : CurrentNode.Next;
        }
    }
}
