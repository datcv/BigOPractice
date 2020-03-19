using System;
using System.Collections.Generic;
using System.Linq;

namespace _102.BinaryTreeLevelOrderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20){
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            var r = LevelOrder(root);
            
            var d = string.Join(Environment.NewLine, r.Select(x => string.Join(", ", x)));
            Console.WriteLine(d);
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            var result = new List<IList<int>>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var count = queue.Count;
                var list = new List<int>(count);
                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    list.Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                result.Add(list);
            }

            return result;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
