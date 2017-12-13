using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day12
{
    // connected component
    // https://en.wikipedia.org/wiki/Connected_component_%28graph_theory%29
    class Day_12
    {
        public static void Do(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var pipes = lines[0].Split(',').ToList();


            Console.Write($"Day 12: Number of Programs connected to 0: {0}");
            Console.ReadLine();
        }
    }
}
