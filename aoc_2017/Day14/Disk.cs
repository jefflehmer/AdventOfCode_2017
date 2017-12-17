using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day14
{
    class Disk
    {
        public const int Size = 128;

        public List<string> GridRows { get; set; }

        public Disk()
        {
            GridRows = new List<string>(Size);
        }

        public int UsedSquares()
        {
            var count = 0;

            // convert strings to bytes then search the stream of 1s and 0s to count the number of 1s
            foreach (var row in GridRows)
            {
                var b2 = StringToByteArray(row);
                count += b2.Sum(bite => SparseBitcount(int.Parse(bite.ToString())));
            }

            return count;
        }

        // so#321370
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        // https://www.dotnetperls.com/bitcount
        static int SparseBitcount(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                n &= (n - 1);
            }
            return count;
        }
    }
}
