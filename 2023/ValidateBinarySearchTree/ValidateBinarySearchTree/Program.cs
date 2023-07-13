using System;

namespace ValidateBinarySearchTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsValidBST(new TreeNode(2) { left = new TreeNode(1), right = new TreeNode(3)}));
            Console.WriteLine(false == new Solution().IsValidBST(new TreeNode(5) { left = new TreeNode(1), right = new TreeNode(4) {left = new TreeNode(3), right = new TreeNode(6)}}));
            Console.WriteLine(false == new Solution().IsValidBST(new TreeNode(5) { left = new TreeNode(4), right = new TreeNode(6) {left = new TreeNode(3), right = new TreeNode(7)}}));
        }
    }
}