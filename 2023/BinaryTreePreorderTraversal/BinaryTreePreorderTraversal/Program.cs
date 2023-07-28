using System;

namespace BinaryTreePreorderTraversal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1,2,3" == string.Join(",", new Solution().PreorderTraversal(new TreeNode(1, null, new TreeNode(2, new TreeNode(3))))));
            Console.WriteLine("1,4,2,3" == string.Join(",", new Solution().PreorderTraversal(new TreeNode(1, new TreeNode(4, new TreeNode(2)), new TreeNode(3)))));
        }
    }
}