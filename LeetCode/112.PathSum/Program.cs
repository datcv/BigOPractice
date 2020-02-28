using System;
using System.Collections.Generic;
namespace _112.PathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(5)
            {
                left = new TreeNode(4){
                    left = new TreeNode(11){
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8){
                    left = new TreeNode(13),
                    right  = new TreeNode(4){
                        right = new TreeNode(1)
                    }

                }
            };

            Console.WriteLine(HasPathSum(root, 22));
        }


        public static bool HasPathSum(TreeNode root, int sum)
        {

            var nodeStack = new Stack<TreeNode>();
            nodeStack.Push(root);
            var count = 0;
            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                count += node.val;
                if (node.left == null && node.right == null)
                {
                    if (count == sum)
                    {
                        return true;
                    }
                    else
                    {
                        count -= node.val;
                    }
                }

                if (node.right != null)
                {
                    nodeStack.Push(node.right);
                }

                if (node.left != null)
                {
                    nodeStack.Push(node.left);
                }
            }

            return false;

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
