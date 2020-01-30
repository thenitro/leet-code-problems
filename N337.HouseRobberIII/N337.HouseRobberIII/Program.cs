using System;
using System.Collections.Generic;

namespace N337.HouseRobberIII
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree1 = new TreeNode(3)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(3)
                },
                right = new TreeNode(3)
                {
                    right = new TreeNode(1)
                }
            };

            Console.WriteLine(7 == new Solution().Rob(tree1));
            
            var tree2 = new TreeNode(3)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(5)
                {
                    right = new TreeNode(1)
                }
            };
            
            Console.WriteLine(9 == new Solution().Rob(tree2));
            
            Console.WriteLine(0 == new Solution().Rob(null));
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
    public int Rob(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var result = Helper(root);

        return Math.Max(result[0], result[1]);
    }

    private int[] Helper(TreeNode node)
    {
        var result = new int[2];

        if (node == null)
        {
            return result;
        }

        var left = Helper(node.left);
        var right = Helper(node.right);

        result[0] = node.val + left[1] + right[1];
        result[1] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);

        return result;
    }
}