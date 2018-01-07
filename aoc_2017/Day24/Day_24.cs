using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day24
{
    class Day_24
    {
        public static void Do(string srcFile)
        {
            Do_1(srcFile);
            Do_2(srcFile);

            Console.ReadLine();
        }

        public static void Do_1(string srcFile)
        {
            var pieces = System.IO.File.ReadAllLines(srcFile);

            var components = new List<Component>(pieces.Length);
            components.AddRange(pieces.Select(piece => new Component(piece.Split('/').Select(int.Parse).ToList()) ));

            const int StartingPin = 0;
            var zeroPinComponents = components.Where(c => c.Ports.Contains(StartingPin));
            var strengths = new List<int>(zeroPinComponents.Count());
            foreach (var zeroPinComponent in zeroPinComponents)
            {
                var openPort = (zeroPinComponent.Ports.Count(p => p != StartingPin) == 1) ? zeroPinComponent.Ports.First(p => p != StartingPin) : StartingPin;
                strengths.Add(zeroPinComponent.Strongest(components, openPort));
            }

            Console.WriteLine($"Day 24.1: Strength of strongest bridge: { strengths.Max() }");
        }

        public static void Do_2(string srcFile)
        {
            var pieces = System.IO.File.ReadAllLines(srcFile);

            var components = new List<Component>(pieces.Length);
            components.AddRange(pieces.Select(piece => new Component(piece.Split('/').Select(int.Parse).ToList())));

            const int StartingPin = 0;
            var zeroPinComponents = components.Where(c => c.Ports.Contains(StartingPin));
            var lengths = new List<Tuple< int, int > >(zeroPinComponents.Count());
            foreach (var zeroPinComponent in zeroPinComponents)
            {
                var openPort = (zeroPinComponent.Ports.Count(p => p != StartingPin) == 1) ? zeroPinComponent.Ports.First(p => p != StartingPin) : StartingPin;
                lengths.Add(zeroPinComponent.Longest(components, openPort));
            }

            var longest = lengths.Where(c => c.Item1 == lengths.Max(t => t.Item1));

            Console.WriteLine($"Day 24.2: Strength of longest bridge: { longest.Max().Item2 }");
        }
    }
}
