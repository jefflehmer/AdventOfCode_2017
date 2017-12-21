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

            const int OneBillionTimes = 1000000000 % 48;

            var troupe = new Dancers();
            for (int i = 0; i < OneBillionTimes; i++)
            {
                foreach (var step in steps)
                {
                    var movement = new Move(step);
                    troupe.Step(movement);
                }
                /* used the following to determine a cycle of 48
                    which we use to modulus the number of cycles to speed up.
                    the final number of loops is really only 16! bpcekomfgjdlinha
                if (troupe.CurrentLineUp == "abcdefghijklmnop")
                    break;
                */
            }

            Console.WriteLine($"Day 16: Programs Standing Order: { troupe.CurrentLineUp }");
            Console.ReadLine();
        }
    }
}
