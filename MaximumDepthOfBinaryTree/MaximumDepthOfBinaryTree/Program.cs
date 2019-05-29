using System;

namespace MaximumDepthOfBinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MaxDepth(
                new TreeNode(3)
                {
                    left = new TreeNode(9),
                    right = new TreeNode(20)
                    {
                        left = new TreeNode(15),
                        right = new TreeNode(7),
                    }
                }));
        }
    }
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    public int MaxDepth(TreeNode root) {
        if (root == null)
        {
            return 0;
        }

        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
    }
}