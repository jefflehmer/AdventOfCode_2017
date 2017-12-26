using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day19
{
    class Day_19
    {
        public static void Do(string srcFile)
        {
            var paths = System.IO.File.ReadAllLines(srcFile);

            var diagram = new RoutingDiagram { Paths = paths };
            var success = diagram.TracePath();

            Console.WriteLine($"Day 19: Letters seen: { diagram.Letters }  Steps taken: { diagram.Steps }");
            Console.ReadLine();
        }
    }
}
