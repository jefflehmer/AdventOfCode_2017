using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day12
{
    // connected component
    // https://en.wikipedia.org/wiki/Connected_component_%28graph_theory%29
    class Day_12
    {
        public static void Do(string srcFile)
        {
            var pipes = System.IO.File.ReadAllLines(srcFile);
            var nodes = pipes.Select(GraphNode.Parse).ToDictionary(node => node.Index);

            foreach (var node in nodes)
            {
                foreach (var path in node.Value.Paths)
                    node.Value.Nodes.Add(nodes[path]);
            }

            const int programID = 0;
            var connections = GraphNode.VisitConnectedNodes(nodes[programID]); // marks nodes as "visited"

            // how many nodes have not been visited yet?
            var groups = 1;  // 1 group already visited
            foreach (var node in nodes)
            {
                if (node.Value.Visited == false)
                {
                    groups++;
                    GraphNode.VisitConnectedNodes(node.Value); // mark the nodes connected to this one
                }
            }


            Console.Write($"Day 12: Node 0 connections: {connections}  Number of Groups: {groups}");
            Console.ReadLine();
        }
    }
}
