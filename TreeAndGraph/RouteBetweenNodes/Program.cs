using System;

namespace RouteBetweenNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new Node("1");
            var node2 = new Node("2");
            var node3 = new Node("3");
            var node4 = new Node("4");
            var node5 = new Node("5");
            var node6 = new Node("6");
            var node7 = new Node("7");
            var node8 = new Node("8");
            var node9 = new Node("9");

            node1.Children = new Node[] { node2, node3 };
            node2.Children = new Node[] { node4, node5 };
            node3.Children = new Node[] { node6, node7 };
            node4.Children = new Node[] { node5 };
            node9.Children = new Node[] { node4 };

            var from = node1;
            var to = node5;
            Console.WriteLine($"Route {from.Name} => {to.Name}: {HasARoute(from, to)}");
            Console.WriteLine($"Route {to.Name} => {from.Name}: {HasARoute(to, from)}");
        }


        private static bool HasARoute(Node from, Node to)
        {
            if (from == null || to == null)
            {
                return false;
            }

            var travelStack = new System.Collections.Generic.Stack<Node>();
            travelStack.Push(from);
            while(travelStack.Count > 0)
            {
                var node = travelStack.Pop();
                if (node.Name == to.Name)
                {
                    return true;
                }

                if (node.Children != null && node.Children.Length > 0)
                {
                    for (int i = 0; i < node.Children.Length; i++)
                    {
                        travelStack.Push(node.Children[i]);
                    }
                }
            }

            return false;
        }
    }
}
