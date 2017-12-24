using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day18
{
    class Day_18
    {
        public static void Do(string srcFile)
        {
            var instructions = System.IO.File.ReadAllLines(srcFile);

            var vcard = new VirtualSoundCard();
            var idx = 0L;
            do
            {
                idx += vcard.Invoke(instructions[idx]);
            } while (idx >= 0 && idx < instructions.Length);
  
            Console.WriteLine($"Day 18: Value of the recovered frequency: { vcard.LastFrequency }");
            Console.ReadLine();
        }
    }
}
