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
        public int Depth { get; set; }
        public int Port1 => Ports[0];
        public int Port2 => Ports[1];

        public Component(List<int> ports)
        {
            Ports = ports;
            InUse = false;
            Depth = 0;
        }

        // recursive method
        public int Construct(List<Component> components, int port)
        {
            InUse = true;
            Depth++;

            var matchingPinComponents = components.Where(c => !c.InUse && c.Ports.Contains(port)); // collect all the unused components that have a matching port
            if (!matchingPinComponents.Any())
            {
                InUse = false;
                return this.Strength;//.Reset();
            }

            // recurse down each component with a matching pin to get a collection of their strengths
            var descendantStrengths = new List<int>(matchingPinComponents.Count());
            foreach (var matchingPinComponent in matchingPinComponents)
            {
                var openPort = (matchingPinComponent.Ports.Count(p => p != port) == 1) ? matchingPinComponent.Ports.First(p => p != port) : port;
                descendantStrengths.Add(matchingPinComponent.Construct(components, openPort));
            }

            InUse = false;
            return this.Strength + descendantStrengths.Max();
        }
    }
}
