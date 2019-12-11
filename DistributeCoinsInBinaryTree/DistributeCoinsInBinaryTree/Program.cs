using System;

namespace DistributeCoinsInBinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree1 = new TreeNode(3)
            {
                left = new TreeNode(0),
                right = new TreeNode(0)
            };

            Console.WriteLine(2 == new Solution().DistributeCoins(tree1));

            var tree2 = new TreeNode(0)
            {
                left = new TreeNode(3),
                right = new TreeNode(0)
            };

            Console.WriteLine(3 == new Solution().DistributeCoins(tree2));

            var tree3 = new TreeNode(1)
            {
                left = new TreeNode(0)
                {
                    right = new TreeNode(3)
                },
                right = new TreeNode(0)
            };

            Console.WriteLine(4 == new Solution().DistributeCoins(tree3));
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
    private int _numMoves = 0;
    
    public int DistributeCoins(TreeNode root)
    {
        _numMoves = 0;
        GiveCoins(root);
        return _numMoves;
    }

    private int GiveCoins(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        var left = GiveCoins(node.left);
        var right = GiveCoins(node.right);

        _numMoves += Math.Abs(left) + Math.Abs(right);

        return node.val + left + right - 1;
    }
}