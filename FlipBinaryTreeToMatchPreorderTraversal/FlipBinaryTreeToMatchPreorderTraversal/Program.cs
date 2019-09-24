using System;
using System.Collections.Generic;

namespace FlipBinaryTreeToMatchPreorderTraversal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result =
                new Solution().FlipMatchVoyage(
                    new TreeNode(1)
                    {
                        left = new TreeNode(2)
                    },
                    new[] {2, 1});
            Console.WriteLine(string.Join(",", result));
            
            var result2 =
                new Solution().FlipMatchVoyage(
                    new TreeNode(1)
                    {
                        left = new TreeNode(2),
                        right = new TreeNode(3)
                    },
                    new[] { 1, 3, 2});
            Console.WriteLine(string.Join(",", result2));
            
            var result3 =
                new Solution().FlipMatchVoyage(
                    new TreeNode(1)
                    {
                        left = new TreeNode(2),
                        right = new TreeNode(3)
                    },
                    new[] { 1, 2, 3});
            Console.WriteLine(string.Join(",", result3));
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
    private List<int> _flipped;
    private int _index;
    private int[] _voyage;

    public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
    {
        _flipped = new List<int>();
        _index = 0;
        _voyage = voyage;

        Dfs(root);

        if (_flipped.Count != 0 && _flipped[0] == -1)
        {
            _flipped.Clear();
            _flipped.Add(-1);
        }

        return _flipped;
    }

    private void Dfs(TreeNode node)
    {
        if (node == null)
        {
            return;
        }

        if (node.val != _voyage[_index++])
        {
            _flipped.Clear();
            _flipped.Add(-1);
            return;
        }

        if (_index < _voyage.Length && node.left != null && node.left.val != _voyage[_index])
        {
            _flipped.Add(node.val);
            Dfs(node.right);
            Dfs(node.left);
        }
        else
        {
            Dfs(node.left);
            Dfs(node.right);
        }
    }
}