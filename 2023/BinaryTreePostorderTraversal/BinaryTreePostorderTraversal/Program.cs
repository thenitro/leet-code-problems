using System;

namespace BinaryTreePostorderTraversal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().PostorderTraversal(new TreeNode(3)
                { left = new TreeNode(1), right = new TreeNode(2) })));
            Console.WriteLine(string.Join(",", new Solution().PostorderTraversal(new TreeNode(3)
                { left = new TreeNode(2), right = new TreeNode(4) { right = new TreeNode(1) } })));
        }
    }
}