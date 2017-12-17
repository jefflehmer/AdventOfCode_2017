using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day14
{
    class Day_14
    {
        public static void Do()
        {
            var input = "flqrgnkx"; // test input
            //var input = "wenycdww"; // puzzle input

            var disk = new Disk();

            for (int i = 0; i < Disk.Size; i++)
            {
                var knot = new Knot(256, $"{input}-{i}");
                var dense = knot.Hash();

                disk.GridRows.Add(dense);
            }

            var numUsedSquares = disk.UsedSquares();


            Console.Write($"Day 14: Number of squares used: {numUsedSquares}");
            Console.ReadLine();
        }
    }
}
