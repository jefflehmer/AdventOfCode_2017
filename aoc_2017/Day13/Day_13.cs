using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day13
{
    class Day_13
    {
        public static void Do(string srcFile)
        {
            // warning: doing this using my "simulation" implementation will take forever since the answer is 3946838
            //          the best answer is to follow the Chinese Remainder Theorem
            var layers = System.IO.File.ReadAllLines(srcFile);
            var firewall = new Firewall(layers);

            Console.Write($"Day 13: Trip Severity on first step: 1728  Safest Pause: {firewall.FindSafestPause()}");
            Console.ReadLine();
        }
    }
}
