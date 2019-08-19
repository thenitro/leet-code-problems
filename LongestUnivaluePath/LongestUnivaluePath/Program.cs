using System;

namespace LongestUnivaluePath
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(1),
                },
                right = new TreeNode(5)
                {
                    right = new TreeNode(5)
                }
            };
            
            Console.WriteLine(2 == new Solution().LongestUnivaluePath(tree));
            
            var tree2 = new TreeNode(1)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(4),
                },
                right = new TreeNode(5)
                {
                    right = new TreeNode(5)
                }
            };
            
            Console.WriteLine(2 == new Solution().LongestUnivaluePath(tree2));
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
    private int _result;
    
    public int LongestUnivaluePath(TreeNode root)
    {
        _result = 0;
        RecursiveHelper(root);
        return _result;
    }

    private int RecursiveHelper(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        var left = RecursiveHelper(node.left);
        var right = RecursiveHelper(node.right);

        var arrowLeft = 0;
        var arrowRight = 0;

        if (node.left != null && node.left.val == node.val)
        {
            arrowLeft += left + 1;
        }
        
        if (node.right != null && node.right.val == node.val)
        {
            arrowRight += right + 1;
        }

        _result = Math.Max(_result, arrowLeft + arrowRight);
        return Math.Max(arrowLeft, arrowRight);
    }
}