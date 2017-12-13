using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using aoc_2017.Day08;

namespace aoc_2017.Day12
{
    class GraphNode
    {
        public int Index { get; set; }
        public List<GraphNode> Nodes { get; set; }
        public List<int> Paths { get; set; }
        public bool Visited { get; set; }

        public GraphNode()
        {
            Index = 0;
            Nodes = new List<GraphNode>();
            Paths = new List<int>();
            Visited = false;
        }

        public static int VisitConnectedNodes(GraphNode graphNode)
        {
            if (graphNode.Visited)
                return 0;

            graphNode.Visited = true;
            return graphNode.Nodes.Sum(VisitConnectedNodes) + 1; // add 1 for this node
        }

        public static GraphNode Parse(string pipe)
        {
            // ex: "2 <-> 0, 3, 4"
            var match = Regex.Match(pipe, @"(?<index>.*) <-> (?<paths>.*$)");
            var index = int.Parse(match.Groups["index"].ToString());
            var paths = match.Groups["paths"].ToString().Split(',').Select(int.Parse).ToList();

            return new GraphNode() { Index = index, Paths = paths };
        }
    }
}
