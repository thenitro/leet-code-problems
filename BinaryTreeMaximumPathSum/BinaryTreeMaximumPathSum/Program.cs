using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeMaximumPathSum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(6 == new Solution().MaxPathSum(new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3),
            }));
            
            Console.WriteLine(42 == new Solution().MaxPathSum(new TreeNode(-10)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7),
                },
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

public class Solution
{
    private int _maxValue;
    
    public int MaxPathSum(TreeNode root)
    {
        _maxValue = int.MinValue;
        
        CalculateSum(root);
        
        return _maxValue;
    }

    private int CalculateSum(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        var left = Math.Max(0, CalculateSum(node.left));
        var right = Math.Max(0, CalculateSum(node.right));

        _maxValue = Math.Max(_maxValue, left + right + node.val);

        return Math.Max(left, right) + node.val;
    }
}