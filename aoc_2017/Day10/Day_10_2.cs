using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day10
{
    public class Day_10_2
    {
        public static void Do(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var bytes = Encoding.ASCII.GetBytes(lines[0]).ToList();

            var stdSuffix = new byte[] { 17, 31, 73, 47, 23 };
            bytes.AddRange(stdSuffix);

            var lengths = bytes.Select(bit => (int)bit).ToList();

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
