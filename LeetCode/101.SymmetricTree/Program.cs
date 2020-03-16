using System;

namespace _101.SymmetricTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(1){
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },
                right = new TreeNode(2){
                    left = new TreeNode(4),
                    right = new TreeNode(3)
                }
            };
            
            var root2 = new TreeNode(1){
                left = new TreeNode(2)
                {                    
                    right = new TreeNode(3)
                },
                right = new TreeNode(2){                    
                    right = new TreeNode(3)
                }
            };

            Console.WriteLine($"Is Symmetric: {IsSymmetric(root)}");
            Console.WriteLine($"Is Symmetric: {IsSymmetric(root2)}");

        }

        public static bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root, root);
        }

        public static bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left?.val != right?.val)
            {
                return false;
            }

            return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
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
