using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day22
{
    class Day_22
    {
        public static void Do(string srcFile)
        {
            Do_1(srcFile);
            Do_2(srcFile);

            Console.ReadLine();
        }

        public static void Do_1(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var map = new Map(lines);

            for (var i = 0; i < 10000; i++)
                map.Burst();

            Console.WriteLine($"Day 22.1: Number of infections from bursts: { map.Infections }");
        }

        public static void Do_2(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var map = new EvolvedMap(lines);

            for (var i = 0; i < 10000000; i++)
                map.Burst();

            Console.WriteLine($"Day 22.2: Number of infections from evolved bursts: { map.Infections }");
        }
    }
}
