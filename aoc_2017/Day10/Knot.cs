using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day10
{

    public class Knot
    {
        public int Count { get; set; }
        private int Index { get; set; }
        private int SkipSize { get; set; }
        public int Product => SparseHash[0] * SparseHash[1];

        public List<int> SparseHash { get; set; }

        public Knot(int count)
        {
            Count = count;
            Index = 0;
            SkipSize = 0;
            SparseHash = Enumerable.Range(0, Count).ToList();
        }

        public void Hash(int length)
        {
            Reverse(length);
            Index = (Index + length + SkipSize++) % Count;
        }

        private void Reverse(int length)
        {
            // we do for-loops that use modulus to handle the circular-ness of the list

            // copy to a separate list..
            var r = Enumerable.Range(0, length).ToList();
            for (var i = 0; i < length; i++)
                r[i] = SparseHash[(Index + i) % Count];

            // ..so that we may leverage the built-in "Reverse()" method
            r.Reverse();

            // ..then copy the results back to mommy
            for (var i = 0; i < length; i++)
                SparseHash[(Index + i) % Count] = r[i];
        }

        public string DenseHash()
        {
            var loose = new byte[16];
            var result = new byte[16];
            var idense = new List<int>(16);

            // run through all 16 blocks of 16 numbers and condense each block
            for (var block = 0; block < 16; block++)
            {
                // grab the next chunk of 16 bytes
                for (var i = 0; i < 16; i++)
                    loose[i] = Convert.ToByte((char)SparseHash[block * 16 + i]); // init "loose"

                // condense those bytes down to one byte
                byte bite = loose[0];
                for (var j = 1; j < 16; j++)
                    bite ^= loose[j]; // xor

                // add that byte to the final hash
                result[block] = bite;
            }

            for (var j = 0; j < 16; j++)
                idense.Add(Convert.ToInt32(result[j]));

            var dense = new StringBuilder(32);
            foreach (var d in idense)
                dense.Append(d.ToString("x2"));

            return dense.ToString();
        }
    }
}
