using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day16
{
    class Day_16
    {
        public static void Do(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var steps = lines[0].Split(',').ToList();

            const int OneBillionTimes = 1;//000000000;

            var troupe = new Dancers();
            for (int i = 0; i < OneBillionTimes; i++)
            {
                foreach (var step in steps)
                {
                    var movement = new Move(step);
                    troupe.Step(movement);
                }
            }

            Console.WriteLine($"Day 16: Programs Standing Order: { troupe.CurrentLineUp }");
            Console.ReadLine();
        }
    }
}
