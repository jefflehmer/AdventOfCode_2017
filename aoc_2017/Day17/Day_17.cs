using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day17
{
    class Day_17
    {
        public static void Do()
        {
            Do_1();
            Do_2();
            Console.ReadLine();
        }

        public static void Do_1()
        {
            const int numInsertions = 2018;

            var spinlock = new SpinLock();
            for (var i = 1; i < numInsertions; i++) // 0 added in SpinLock ctor
                spinlock.Insert(i);

            Console.WriteLine($"Day 17.1: Value after { numInsertions } insertions: { spinlock.After }");
        }

        public static void Do_2()
        {
            const int numSteps = 337;
            const int numInsertions = 50000000;
            var idx = 0;
            var second = 0;

            for (var i = 1; i <= numInsertions; i++)
            {
                idx = (idx + numSteps + 1) % i;
                if (idx == 0)
                    second = i;
            }
            Console.WriteLine($"Day 17.2: Second value { second }");
        }
    }
}
