using System;

namespace DiameterOfBinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
            };
            Console.WriteLine(3 == new Solution().DiameterOfBinaryTree(root));

            var root1 = new TreeNode(1);
            Console.WriteLine(0 == new Solution().DiameterOfBinaryTree(root1));
            
            Console.WriteLine(0 == new Solution().DiameterOfBinaryTree(null));
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
    
    public int DiameterOfBinaryTree(TreeNode root)
    {
        _result = 1;

        DiameterOfBinaryTreeHelper(root);
        
        return _result - 1;
    }

    private int DiameterOfBinaryTreeHelper(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        var l = DiameterOfBinaryTreeHelper(node.left);
        var r = DiameterOfBinaryTreeHelper(node.right);

        _result = Math.Max(_result, l + r + 1);

        return Math.Max(l, r) + 1;
    }
}