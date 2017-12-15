using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day13
{
    class Firewall
    {
        private Dictionary<int, Layer> Layers { get; set; }
        public int TopLayer { get; set; }

        public Firewall()
        {
            Layers = new Dictionary<int, Layer>();
            TopLayer = 0;
        }

        public Firewall(string[] layers) : this()
        {
            var numLayers = layers.Length;
            Layers = new Dictionary<int, Layer>(numLayers);

            for (int i = 0; i < numLayers; i++)
            {
                // ex: "1: 2"
                var match = Regex.Match(layers[i], @"(?<depth>.*): (?<range>.*$)");
                var depth = int.Parse(match.Groups["depth"].ToString());
                var range = int.Parse(match.Groups["range"].ToString());

                Layers.Add(depth, new Layer() { Depth = depth, Range = range, Scanner = 0 });
                TopLayer = TopLayer < depth ? depth : TopLayer;
            }
        }

        // advance the scanners in all known layers by one picosecond
        internal void TicToc()
        {
            foreach (var layer in Layers)
                layer.Value.Advance();
        }

        public int Go()
        {
            var severity = 0;
            var packet = new Packet();
            var outerCaught = false;

            // walk through each layer...one per picosecond
            for (var i = 0; i <= TopLayer; i++)
            {
                var innerCaught = false;
                severity += packet.Next(i, Layers.GetValueOrDefault(i), out innerCaught); // first the packet moves
                outerCaught |= innerCaught;
                TicToc(); // then the clock ticks and all layers advance
            }
            return severity + (outerCaught ? 1 : 0); // quick hack: add 1 if caught so we can guarantee getting caught at zero layer doesn't show a zero severity.
        }

        public int GoSoon(int pause)
        {
            // here's the delay
            for (var tics = 0; tics < pause; tics++)
                TicToc();

            return Go();
        }

        public int FindSafestPause()
        {
            var pause = 0;
            int severity;

            do
            {
                ResetLayers();
                severity = GoSoon(pause++);
            } while (severity > 0);

            return pause - 1;
        }

        private void ResetLayers()
        {
            foreach (var layer in Layers)
                layer.Value.Reset();
        }
    }
}
