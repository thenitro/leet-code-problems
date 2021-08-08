using System.Collections.Generic;

namespace LowestCommonAncestorOfBinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
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
    private TreeNode result;
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        Helper(root, p, q);
        return result;
    }

    private bool Helper(TreeNode node, TreeNode p, TreeNode q)
    {
        if (node == null)
        {
            return false;
        }

        var left = Helper(node.left, p, q) ? 1 : 0;
        var right = Helper(node.right, p, q) ? 1 : 0;

        var mid = (node == p || node == q) ? 1 : 0;

        if (mid + left + right >= 2)
        {
            result = node;
        }

        return mid + left + right > 0;
    }
}