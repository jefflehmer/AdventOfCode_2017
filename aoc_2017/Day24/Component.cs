using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day24
{
    class Component
    {
        public List<int> Ports { get; set; }
        public bool InUse { get; set; }
        public int Strength => Ports.Sum();

        public Component(List<int> ports)
        {
            Ports = ports;
            InUse = false;
            Depth = 0;
        }

        // recursive method for Part One
        public int Strongest(List<Component> components, int port)
        {
            InUse = true;

            var matchingPinComponents = components.Where(c => !c.InUse && c.Ports.Contains(port)); // collect all the unused components that have a matching port
            if (!matchingPinComponents.Any())
            {
                InUse = false;
                return this.Strength;
            }

            // recurse down each component with a matching pin to get a collection of their strengths
            var descendantStrengths = new List<int>(matchingPinComponents.Count());
            foreach (var matchingPinComponent in matchingPinComponents)
            {
                var openPort = (matchingPinComponent.Ports.Count(p => p != port) == 1) ? matchingPinComponent.Ports.First(p => p != port) : port;
                descendantStrengths.Add(matchingPinComponent.Strongest(components, openPort));
            }

            InUse = false;
            return this.Strength + descendantStrengths.Max();
        }

        // recursive method for Part Two
        public Tuple<int, int> Longest(List<Component> components, int port)
        {
            InUse = true;

            var matchingPinComponents = components.Where(c => !c.InUse && c.Ports.Contains(port)); // collect all the unused components that have a matching port
            if (!matchingPinComponents.Any())
            {
                InUse = false;
                return new Tuple<int, int>(1, Strength);
            }

            // recurse down each component with a matching pin to get a collection of their lengths
            foreach (var matchingPinComponent in matchingPinComponents)
            {
                var openPort = (matchingPinComponent.Ports.Count(p => p != port) == 1) ? matchingPinComponent.Ports.First(p => p != port) : port;
                descendantLengths.Add(matchingPinComponent.Longest(components, openPort));
            }

            InUse = false;
            var longest = descendantLengths.Where(l => l.Item1 == descendantLengths.Max(t => t.Item1));
            var strongest = longest.First(l => l.Item2 == longest.Max(s => s.Item2));
            return new Tuple<int, int>(strongest.Item1 + 1, strongest.Item2 + Strength);
        }
    }
}
