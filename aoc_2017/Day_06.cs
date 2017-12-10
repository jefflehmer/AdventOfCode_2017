using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017
{
    public class Day_06
    {
        public static void Do(string srcFile)
        {
            // create the blocks
            var input = System.IO.File.ReadAllLines(srcFile);
            var blocks = new Blocks(input[0]);

            var numCycles = 0;
            do
            {
                numCycles++;
                var idx = blocks.FindLargestBlockIndex();
                blocks.RedistributeBlocks(idx);

            } while (blocks.HasNotBeenSeenBefore(numCycles));


            Console.Write($"Day 06: Starting Blocks: {blocks.Count}  Cycles: {numCycles}  Loop: {numCycles - blocks.CycleIdx}");
            Console.ReadLine();
        }
    }
}
