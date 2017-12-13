using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day06
{
    public class Blocks
    {
        private List<int> _blocks = new List<int>();
        private HashSet<string> _seen = new HashSet<string>();
        private Dictionary<int, string> _indices = new Dictionary<int, string>();

        public int Count => _blocks.Count;
        public int CycleIdx { get; set; }

        public Blocks(string input)
        {
            _blocks = input.Split('\t').Select(int.Parse).ToList();
        }

        public void RedistributeBlocks(int idx)
        {
            var ctr = _blocks[idx];
            _blocks[idx] = 0;

            for (int i = 0; i < ctr; i++)
                _blocks[(i + 1 + idx) % Count]++;
        }

        public int FindLargestBlockIndex()
        {
            var idx = 0;
            var largest = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_blocks[i] > largest)
                {
                    largest = _blocks[i];
                    idx = i;
                }
            }

            return idx;
        }

        public bool HasNotBeenSeenBefore(int cycle)
        {
            var config = string.Join(" ", _blocks.Select(i => i.ToString()).ToArray());
            var seen = _seen.Add(config);
            if (seen)
                _indices.Add(cycle, config);
            else
                CycleIdx = _indices.FirstOrDefault( x => x.Value == config).Key;

            return seen;
        }
    }
}
