namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;

    class TestTrees
    {
        private static Dictionary<int, Tree<int>> nodesByValue = new Dictionary<int, Tree<int>>();

        static void Main()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                var edge = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var parent = GetNodeByValue(edge[0]);
                var child = GetNodeByValue(edge[1]);

                child.Parent = parent;
                parent.Children.Add(child);
            }

            var pathSum = int.Parse(Console.ReadLine());
            var subtreeSum = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // get root node
            var root = nodesByValue.Values
                .First(node => node.Parent == null);
            Console.WriteLine("Root node: {0}", root.Value);
            Console.WriteLine();

            // get leaf nodes
            var leafs = nodesByValue.Values
                .Where(node => node.Children.Count == 0)
                .OrderBy(node => node.Value)
                .Select(node => node.Value);

            Console.WriteLine("Leaf nodes: {0}", string.Join(", ", leafs));
            Console.WriteLine();

            // get middle nodes
            var middleNodes = nodesByValue.Values
                .Where(node => node.Children.Count > 0 && node.Parent != null)
                .OrderBy(node => node.Value)
                .Select(node => node.Value);

            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middleNodes));
            Console.WriteLine();

            // longest leftmost path
            var lastLeaf = GetLastNode(root);
            Console.WriteLine("Longes path:");
            PrintPath(lastLeaf);
            Console.WriteLine();

            // All paths in the tree with given sum
            var leafsNodes = nodesByValue.Values
                .Where(node => node.Children.Count == 0);

            Console.WriteLine("Paths of sum {0}:", pathSum);
            foreach (var leaf in leafsNodes)
            {
                var sum = CalculatePathSum(leaf);
                if (sum == pathSum)
                {
                    PrintPath(leaf);
                }
            }

            Console.WriteLine();

            // All subtrees with given sum
            Console.WriteLine("Subtrees of sum {0}:", subtreeSum);
            foreach (Tree<int> tree in nodesByValue.Values)
            {
                var nodes = tree.ToList();
                if (tree.ToList().Sum() == subtreeSum)
                {
                    Console.WriteLine("{0} = {1}", string.Join(" + ", nodes), nodes.Sum());
                }
                
            }
            
        }

        static Tree<int> GetNodeByValue(int value)
        {
            if (!nodesByValue.ContainsKey(value))
            {
                var newNode = new Tree<int>(value);
                nodesByValue.Add(value, newNode);
            }

            return nodesByValue[value];
        }

        public static Tree<int> GetLastNode(Tree<int> tree)
        {
            var queue = new Queue<Tree<int>>();
            queue.Enqueue(tree);
            Tree<int> nextNode = null;

            while (queue.Count > 0)
            {
                nextNode = queue.Dequeue();
                var children = nextNode.Children;
                for (int i = children.Count - 1; i >= 0; i--)
                {
                    queue.Enqueue((Tree<int>)children[i]);
                }
            }

            return nextNode;
        }

        public static void PrintPath(Tree<int> node)
        {
            var nextNode = node;
            var parents = new List<int>();
            parents.Add(nextNode.Value);
            var counter = 1;

            while (nextNode.Parent != null)
            {
                parents.Add(nextNode.Parent.Value);
                nextNode = nextNode.Parent;
                counter++;
            }

            parents.Reverse();
            Console.WriteLine("{0} (length = {1})", string.Join(" -> ", parents), counter);
        }

        public static int CalculatePathSum(Tree<int> node)
        {
            var nextNode = node;
            var sum = nextNode.Value;

            while (nextNode.Parent != null)
            {
                nextNode = nextNode.Parent;
                sum += nextNode.Value;
            }

            return sum;
        }

    }
}
