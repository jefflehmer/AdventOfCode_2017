using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aoc_2017.Day11;

namespace aoc_2017
{
    class Day_11
    {
        public static void Do(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var steps = lines[0].Split(',').ToList();

            var grid = new Grid();
            foreach (var step in steps)
                grid.Step((Grid.Direction)Enum.Parse(typeof(Grid.Direction), step.ToUpper()));

            Console.Write($"Day 11.1: Fewest Steps: {grid.OriginToCurrent()}");
            Console.ReadLine();
        }
    }
}
