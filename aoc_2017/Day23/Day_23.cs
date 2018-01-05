using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day23
{
    class Day_23
    {
        public static void Do(string srcFile)
        {
            //Do_1(srcFile);
            Do_2(srcFile);

            Console.ReadLine();
        }

        public static void Do_1(string srcFile)
        {
            var instructions = System.IO.File.ReadAllLines(srcFile);

            var tablet = new Tablet();
            var idx = 0L;
            do
            {
                idx += tablet.Invoke(instructions[idx]);
            } while (idx >= 0 && idx < instructions.Length);

            Console.WriteLine($"Day 23: Number of times 'mul' is invoked: { tablet.MulCount }");
        }

        public static void Do_2(string srcFile)
        {
            var instructions = System.IO.File.ReadAllLines(srcFile);

            var tablet = new Tablet();
            var idx = 0L;
            do
            {
                idx += tablet.Invoke(instructions[idx]);
            } while (idx >= 0 && idx < instructions.Length);

            Console.WriteLine($"Day 23: Number of times 'mul' is invoked: { tablet.MulCount }");
        }
    }
}
