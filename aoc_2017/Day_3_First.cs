using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aoc_2017.Day_3;

namespace aoc_2017
{
    public class Day_3_First
    {
        public static void Do(int steps)
        {
            var square = new Day_3_First();
            square.Dance(steps);
        }

        public void Dance(int steps)
        {
            var blocks = new Manhattan(steps);
            blocks.Walk(steps);

            Console.Write($"Steps: {steps}  Distance {blocks.CalculateDistance()}");
            Console.ReadLine();
        }
    }
}
