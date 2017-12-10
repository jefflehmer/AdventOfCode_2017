using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aoc_2017.Day_03;

namespace aoc_2017
{
    public class Day_03_First
    {
        public static void Do(int steps)
        {
            var square = new Day_03_First();
            square.Dance(steps);
        }

        public void Dance(int steps)
        {
            var blocks = new Manhattan(steps);
            blocks.Walk(steps);

            Console.Write($"Day 03: Steps: {steps}  Distance {blocks.CalculateDistance()}");
            Console.ReadLine();
        }
    }
}
