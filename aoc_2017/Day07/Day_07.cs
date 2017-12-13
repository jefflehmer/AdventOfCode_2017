using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc_2017.Day07
{
    public class Day_07
    {
        public static void Do(string srcFile)
        {
            var lines = System.IO.File.ReadAllLines(srcFile);
            var allNodes = lines.Select(line => new TreeNode(line)).ToDictionary(node => node.Name);

            foreach (var node in allNodes)
                node.Value.PopulateChildren(allNodes);

            var treeRoot = allNodes.First().Value.FindRoot();
            var rootSum = treeRoot.CalculateSum();
            var badNode = treeRoot.FindUnbalancedNode(allNodes);
            var correctedWeight = treeRoot.DetermineCorrectedWeight(badNode);
            Console.Write($"Day 07: TreeRoot Name: {treeRoot.Name}  Unbalanced Node: {badNode.Name}  CorrectedWeight: {correctedWeight}");
            Console.ReadLine();
        }
    }
}
