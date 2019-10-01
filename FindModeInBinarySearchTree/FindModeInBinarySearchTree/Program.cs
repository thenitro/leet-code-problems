using System;
using System.Collections.Generic;

namespace FindModeInBinarySearchTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().FindMode(new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    left = new TreeNode(2)
                }
            });
            Console.WriteLine(string.Join(",", result));
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
    public int[] FindMode(TreeNode root)
    {
        var result = new List<int>();
        var dict = new Dictionary<int, int>();

        var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

        var maxAmount = int.MinValue;
            
        while (queue.Count > 0)
        {
            var next = queue.Dequeue();
            if (next == null)
            {
                continue;
            }

            dict[next.val] = dict.ContainsKey(next.val) ? dict[next.val] + 1 : 1;

            if (dict[next.val] > maxAmount)
            {
                maxAmount = dict[next.val];
            }
            
            queue.Enqueue(next.left);
            queue.Enqueue(next.right);
        }

        foreach (var kv in dict)
        {
            if (kv.Value == maxAmount)
            {
                result.Add(kv.Key);
            }
        }

        return result.ToArray();
    }
}