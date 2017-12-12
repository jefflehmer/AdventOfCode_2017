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
            var left = new byte[16];
            var right = new byte[16];
            var idense = new List<int>(16);

            for (var i = 0; i < 16; i++) left[i] = Convert.ToByte((char)SparseHash[i]); // init "left"
            for (var i = 1; i < 16; i++) // then run through the rest of the words and xor them to "left"
            {
                for (var j = 0; j < 16; j++)
                    right[j] = Convert.ToByte((char)SparseHash[i * 16 + j]); // init "right"

                for (var j = 0; j < 16; j++)
                    left[j] = (byte)(left[j] ^ right[j]);
            }

            for (var j = 0; j < 16; j++)
                idense.Add(Convert.ToInt32(left[j]));

            var dense = new StringBuilder(32);
            foreach (var d in idense)
                dense.Append(d.ToString("X2"));

            return dense.ToString();
        }
    }
}
