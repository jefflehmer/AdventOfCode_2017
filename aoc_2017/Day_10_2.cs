using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aoc_2017.Day10;

namespace aoc_2017
{
    public class Day_10_2
    {
        public static void Do(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var StdSuffix = new byte[] { 7, 1, 3, 7, 3 };
            var bytes = Encoding.ASCII.GetBytes(lines[0]).ToList();
            bytes.AddRange(StdSuffix);
            var lengths = bytes.Select(bit => (int)bit);

            var NumRounds = 64;
            var knot = new Knot(256);
            for (int i = 0; i < NumRounds; i++)
            {
                foreach (var length in lengths)
                    knot.Hash(length);
            }

            Console.Write($"Day 10.2: DenseHash: {knot.DenseHash()}");
            Console.ReadLine();
        }
    }
}
