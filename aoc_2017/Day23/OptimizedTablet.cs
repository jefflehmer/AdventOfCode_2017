using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day23
{
    class OptimizedTablet
    {
        private int b = 106700;
        private int c = 123700;
        private int h = 0;

        // counts the number of composite numbers between 106700 and 123700
        public int Invoke()
        {
            for  (; b <= c; b += 17)
            {
                if (IsComposite(b))
                    h++;
            }

            return h;
        }

        private bool IsComposite(int n)
        {
            return !IsPrime(n);
        }

        // https://en.wikipedia.org/wiki/Primality_test
        private bool IsPrime(int n)
        {
            if (n <= 1)
                return false;
            if (n <= 3)
                return true;
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            var i = 5;
            while (i * i <= n)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
                i += 6;
            }
            return true;
        }
    }
}
