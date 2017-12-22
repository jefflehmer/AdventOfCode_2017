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
            var NumInsertions = 2018;

            var spinlock = new SpinLock();
            for (int i = 1; i < NumInsertions; i++) // 0 added in SpinLock ctor
                spinlock.Insert(i);

            Console.WriteLine($"Day 17: Value after { NumInsertions } insertions: { spinlock.After }");
            Console.ReadLine();
        }
    }
}
