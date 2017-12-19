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
            //var input = "flqrgnkx"; // test input
            var input = "wenycdww"; // puzzle input

            var disk = new Disk();

            for (int i = 0; i < Disk.Size; i++)
            {
                var knot = new Knot(256, $"{input}-{i}");
                var dense = knot.Hash();

                disk.HexGridRows.Add(dense); // TODO: move to Disk class ctor
            }

            var numUsedSquares = disk.UsedSquares();
            var groups = disk.Groups();


            Console.Write($"Day 14: Squares used: { numUsedSquares }, Number of groups: { groups }");
            Console.ReadLine();
        }
    }
}
