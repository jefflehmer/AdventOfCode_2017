using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day10
{
    public class Day_10_1
    {
        public static void Do(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var lengths = lines[0].Split(',').Select(int.Parse).ToList();

            var knot = new Knot(256);
            foreach (var length in lengths)
                knot.Hash(length);

            Console.Write($"Day 10.1: Product: {knot.Product}");
            Console.ReadLine();
        }
    }
}
