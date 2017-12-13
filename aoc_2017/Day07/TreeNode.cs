using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc_2017.Day07
{
    public class TreeNode
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Sum { get; set; }

        public TreeNode Parent { get; set; }
        public List<TreeNode> Children { get; set; }

        private TreeNode()
        {
        }
         
        public TreeNode(string line)
        {
            Children = new List<TreeNode>();

            try
            {
                //string sample = @"navfz (187) -> jviwcde, wfwor, vpfabxa";
                var match = Regex.Match(line, @"(?<name>.*) \((?<weight>.*)\) -> (?<children>.*$)");
                if (match.Groups["children"].Length == 0)
                    match = Regex.Match(line, @"(?<name>.*) \((?<weight>.*)\)$");
                else
                    IncludeChildren(match.Groups["children"].ToString());

                Name = match.Groups["name"].ToString();
                Weight = int.Parse(match.Groups["weight"].ToString());
                Sum = 0;
            }
            catch (Exception /*ex*/)
            {
                //Add appropriate error handling here
                throw;
            }
        }

        private void IncludeChildren(string children)
        {
            var childNames = children.Split(',');
            foreach (var childName in childNames)
                Children.Add(new TreeNode { Name = childName.Trim() });
        }

        public void PopulateChildren(Dictionary<string, TreeNode> allNodes)
        {
            var numChildren = Children.Count;
            for (var i = 0; i < numChildren; i++)
            {
                Children[i] = allNodes[Children[i].Name]; // yes, we are assuming the node always will be found
                Children[i].Parent = this;
            }
        }

        public TreeNode FindRoot()
        {
            while (Parent != null)
                return Parent.FindRoot();

            return this;
        }

        public TreeNode FindUnbalancedNode(Dictionary<string, TreeNode> allNodes)
        {
            foreach (var tvalue in allNodes)
            {
                var node = tvalue.Value;
                if (node.Children.Count > 0)
                {
                    var sum = node.Children.Sum(child => child.Sum);
                    if (sum/node.Children.Count != node.Children.First().Sum)
                        return node;
                }
            }

            return null;
        }

        // note: this is a quick hack for this competition. not production quality.
        public int DetermineCorrectedWeight(TreeNode badNode)
        {
            // we know there have to be at least 3 to cause an imbalance that is _locally_ correctable
            TreeNode node0 = badNode.Children[0];
            TreeNode node1 = null;

            // find the two different values
            for (var i = 2; i < badNode.Children.Count; i++)
            {
                if (badNode.Children[i].Sum != node0.Sum)
                {
                    node1 = badNode.Children[i];
                    break;
                }
            }

            // then count instances of each
            var count1 = 0; var count2 = 0;
            foreach (var child in badNode.Children)
            {
                if (child.Sum == node0.Sum)
                    count1++;
                if (child.Sum == node1.Sum)
                    count2++;
            }

            // we're making lots of assumptions about the quality of the data here
            if (count1 > count2)
                return node1.Weight - Math.Abs(node0.Sum - node1.Sum);
            else
                return node0.Weight - Math.Abs(node0.Sum - node1.Sum);
        }

        internal int CalculateSum()
        {
            Sum = Weight;

            foreach (var child in Children)
                Sum += child.CalculateSum();

            return Sum;
        }

        /*
                // use Compare rather than overload ==, !=, and Equals operators and GetHashCode()
                private bool Compares(TreeNode node)
                {
                    return Name == node.Name;
                }

                internal void AddNode(TreeNode treeNode)
                {
                    var node = FindDescendantNode(treeNode);
                    if (node == null)
                    {
                        // then the root node MUST be a child node of the treeNode
                        node = FindChildNode(treeNode);
                    }
                }

                // performs a depth-first search
                private TreeNode FindDescendantNode(TreeNode treeNode)
                {
                    foreach (var child in Children)
                    {
                        if (child.Compares(treeNode))
                            return child;
                        return FindDescendantNode(child);
                    }

                    return null;
                }

                private TreeNode FindChildNode(TreeNode treeNode)
                {
                    return Children.FirstOrDefault(Compares);
                }
        */
    }
}
