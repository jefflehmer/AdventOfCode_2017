using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day14
{
    class Disk
    {
        public const int Size = 128;

        public List<string> HexGridRows { get; set; }
        public List<string> BitGridRows { get; set; }

        public Disk()
        {
            HexGridRows = new List<string>(Size);
            BitGridRows = new List<string>(Size);
        }

        public int UsedSquares()
        {
            var count = 0;

            // convert strings to bytes then search the stream of 1s and 0s to count the number of 1s
            foreach (var row in HexGridRows)
            {
                var bites = HexStringToByteArray(row);
                count += bites.Sum(bite => SparseBitcount(int.Parse(bite.ToString())));
            }

            return count;
        }

        public int Groups()
        {
            var groups = 0;

            // convert strings of hexes to strings of bits (why not int arrays?)
            // TODO: move to ctor
            foreach (var row in HexGridRows)
                BitGridRows.Add(HexStringToByteStringArray(row));

            // initialize the grid of visited sectors
            var visited = new bool[Size, Size]; // TODO: use a HashSet of tuple strings instead!?
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    visited[i, j] = false;
                }
            }

            // now traverse all the sectors looking for groups and marking them as visited
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (!visited[i, j])
                    {
                        if (Visit(i, j, visited))
                            groups++;
                    }
                }
            }

            return groups;
        }

        // recursive call to visit all connected sectors, like a Flood Fill algorithm
        private bool Visit(int i, int j, bool[,] visited)
        {
            if (visited[i, j] || IsZero(i, j))
                return false;

            visited[i, j] = true;

            // continue marking any contiguous sectors
            try
            {
                if (i > 0)
                    Visit(i - 1, j, visited);
                if (i < Size - 1)
                    Visit(i + 1, j, visited);
                if (j > 0)
                    Visit(i, j - 1, visited);
                if (j < Size - 1)
                    Visit(i, j + 1, visited);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }

            return true;
        }

        private bool IsZero(int x, int y)
        {
            var row = BitGridRows[x];
            return row[y] == '0';
        }

        // so#321370
        private byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        // https://www.dotnetperls.com/bitcount
        int SparseBitcount(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                n &= (n - 1);
            }
            return count;
        }

        public string HexStringToByteStringArray(string hex)
        {
            var hexes =
                (from Match m in Regex.Matches(hex, "..")
                 select m.Value).ToArray();
            var hexbites = hexes.Select(x => Convert.ToString(Convert.ToInt32(x, 16), 2).PadLeft(8, '0')); // convert base-16 to base-2
            var bitestring = string.Join(string.Empty, hexbites);
            return bitestring;
        }
    }
}