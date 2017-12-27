using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day20
{
    class Day_20
    {
        public static void Do(string srcFile)
        {
            var rawParticles = System.IO.File.ReadAllLines(srcFile);

            var swarm = new Swarm(rawParticles);

            const int SampleSetSize = 1000;
            for (var i = 0; i < SampleSetSize; i++)
                swarm.Next();

            //Console.WriteLine($"Day 20: Closest particle: { swarm.ClosestLongTerm.Index }"); // this will only work when you comment out the EliminateCollisions() call in Swarm. Don't have the time to care to fix it.
            Console.WriteLine($"Day 20: Particles remaining: { swarm.Particles.Count }");
            Console.ReadLine();
        }
    }
}
