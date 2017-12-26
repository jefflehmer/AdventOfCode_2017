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
            Do_1(srcFile);
            //Do_2(srcFile);
            Console.ReadLine();
        }
        public static void Do_1(string srcFile)
        {
            var instructions = System.IO.File.ReadAllLines(srcFile);

            var vcard = new VirtualSoundCard();
            var idx = 0L;
            do
            {
                idx += vcard.Invoke(instructions[idx]);
            } while (idx >= 0 && idx < instructions.Length);

            Console.WriteLine($"Day 18.1: Value of the recovered frequency: { vcard.LastFrequency }");
        }

        public static void Do_2(string srcFile)
        {
            var instructions = System.IO.File.ReadAllLines(srcFile);

            var duet1 = new Bubbler();
            duet1.Registers["p"] = 0;

            var duet2 = new Bubbler { Partner = duet1 };
            duet2.Registers["p"] = 1;
            duet1.Partner = duet2;

            var task1 = new Task<long>(() => duet1.Process(instructions));
            var task2 = new Task<long>(() => duet2.Process(instructions));

            // start the race
            task1.Start();
            task2.Start();
            Task.WaitAll(task1, task2);
            
            Console.WriteLine($"Day 18.2: Number of times value sent to l: { duet2.SendCount }");
        }
    }
}
