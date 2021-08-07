using System;
using System.Collections.Generic;

namespace FindLargestValueInEachTreeRow
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

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public IList<int> LargestValues(TreeNode root)
    {
        var results = new List<int>();

        if (root == null)
        {
            return results;
        }

        var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

        var count = 1;
        var currentMax = int.MinValue;
            
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            count--;

            currentMax = Math.Max(node.val, currentMax);

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }

            if (count == 0)
            {
                results.Add(currentMax);
                currentMax = int.MinValue;
                count = queue.Count;
            }
        }
        
        return results;
    }
}