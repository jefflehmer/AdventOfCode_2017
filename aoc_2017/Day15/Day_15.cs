using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day15
{
    class Day_15
    {
        const long f_a = 16807; // factor A
        const long f_b = 48271; // factor B
        const long MersennePrime = 2147483647; // modulus value - is a Mersenne Prime (2^31 - 1)
        const long Mask = 0xffff;

        public static void Do()
        {
            Do_1();
            Do_2();

            Console.ReadLine();
        }

        public static void Do_1()
        {
            const long Iterations = 40000000; // 40 million iterations

            long g_a = 634; // generator A with starting value (65 test, 634 actual)
            long g_b = 301; // generator B with starting value (8921 test, 301 actual)

            var count = 0;
            for (long i = 0; i < Iterations; i++)
            {
                g_a = (g_a * f_a) % MersennePrime;
                g_b = (g_b * f_b) % MersennePrime;

                if ((g_a & Mask) == (g_b & Mask))
                    count++;
            }

            Console.WriteLine($"Judges Final Count 1: { count }");
        }

        public static void Do_2()
        {
            const long Iterations = 5000000; // 5 million iterations

            long g_a = 634; // generator A with starting value (65 test, 634 actual)
            long g_b = 301; // generator B with starting value (8921 test, 301 actual)

            Queue<long> q_a = new Queue<long>();
            Queue<long> q_b = new Queue<long>();

            // only add them to the queue's if they div evenly

            do
            {
                g_a = (g_a*f_a)%MersennePrime;
                if (g_a%4 == 0)
                    q_a.Enqueue(g_a);
            } while (q_a.Count < Iterations);

            do
            {
                g_b = (g_b*f_b)%MersennePrime;
                if (g_b%8 == 0)
                    q_b.Enqueue(g_b);
            } while (q_b.Count < Iterations);

            var count = 0;
            // now compare the values in the queues
            do
            {
                if ((q_a.Dequeue() & Mask) == (q_b.Dequeue() & Mask))
                    count++;
            } while (q_a.Any() && q_b.Any());


            Console.WriteLine($"Judges Final Count 2: { count }");
        }
    }
}
