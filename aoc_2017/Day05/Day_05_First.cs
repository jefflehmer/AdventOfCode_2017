using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day05
{
    class Day_05_First
    {
        public static void Do(string srcFile)
        {
            var input = System.IO.File.ReadAllLines(srcFile);
            var offsets = input.Select(int.Parse).ToList();

            var steps = FindTheExit1(offsets);
            //var steps = FindTheExit2(offsets);

            Console.Write($"Day 05: Offsets: {offsets.Count}  Steps to exit: {steps}");
            Console.ReadLine();
        }

        private static int FindTheExit2(List<int> offsets)
        {
            var steps = 0;
            var idx = 0;
            var numOffsets = offsets.Count;

            do
            {
                var tmp = idx;
                idx += offsets[tmp];
                offsets[tmp] += (offsets[tmp] >= 3) ? -1 : 1;
                steps++;
            } while (idx < numOffsets);

            return steps;
        }

        private static int FindTheExit1(List<int> offsets)
        {
            var steps = 0;
            var idx = 0;
            var numOffsets = offsets.Count;

            do
            {
                var tmp = idx;
                idx += offsets[tmp]++;
                steps++;
            } while (idx < numOffsets);

            return steps;
        }
    }
}