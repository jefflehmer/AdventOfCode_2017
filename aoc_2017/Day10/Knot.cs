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
            var xor = new byte[16];
            var idense = new List<int>(16);

            for (var i = 0; i < 16; i++)
            {
                for (var i1 = 0; i1 < 16; i1++) left[i1] = Convert.ToByte((char)SparseHash[i * i1]);
                for (var ii = 1; ii < 16; ii++)
                {
                    for (var j = 0; j < 16; j++)
                        right[j] = Convert.ToByte((char)SparseHash[i * ii + j]);
                    left[ii] = (byte)(left[ii] ^ right[ii]);
                }
                idense.Add(BitConverter.ToInt32(left, 0));
            }

            var dense = new StringBuilder(16);
            foreach (var d in idense)
                dense.AppendFormat("{0}", d.ToString("X2"));

            return dense.ToString();
        }
    }
}
