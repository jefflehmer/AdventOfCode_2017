using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day21
{
    class Day_21
    {
        // i implemented this with real grid objects down to the bottom. not very efficient.
        // i saw someone else had done it through only strings and it was much simpler and probably faster.
        public static void Do(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var rules = lines.Select(Rule.Parse).ToList();

            const int NumIterations = 5;
            var image = Image.StartingImage;
            for (var i = 0; i < NumIterations; i++)
                image.Expand(rules);
                


            Console.WriteLine($"Day 21: Pixels remaining: { image.Pixels }");
            Console.ReadLine();
        }
    }
}
