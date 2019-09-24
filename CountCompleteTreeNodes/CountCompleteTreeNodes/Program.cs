using System;

namespace CountCompleteTreeNodes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5),
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6)
                },
            };

            Console.WriteLine(6 == new Solution().CountNodes(tree));
        }
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x)
    {
        val = x;
    }
}

public class Solution
{
    public int CountNodes(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        return 1 + CountNodes(root.left) + CountNodes(root.right);
    }
}