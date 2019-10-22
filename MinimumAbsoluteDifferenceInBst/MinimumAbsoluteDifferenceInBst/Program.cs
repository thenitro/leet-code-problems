using System;
using System.Collections.Generic;

namespace MinimumAbsoluteDifferenceInBst
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var root = new TreeNode(1)
            {
                right = new TreeNode(3)
                {
                    left = new TreeNode(2)
                }
            };

            Console.WriteLine(1 == new Solution().GetMinimumDifference(root));
            
            var root2 = new TreeNode(236)
            {
                left = new TreeNode(104)
                {
                    right = new TreeNode(227)
                },
                right = new TreeNode(701)
                {
                    right = new TreeNode(911)
                }
            };

            Console.WriteLine(9 == new Solution().GetMinimumDifference(root2));
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
    public int GetMinimumDifference(TreeNode root)
    {
        var allNodes = new List<TreeNode>();
        
        var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            allNodes.Add(node);

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }
            
            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }
        }

        var min = int.MaxValue;

        foreach (var nodeA in allNodes)
        {
            foreach (var nodeB in allNodes)
            {
                if (nodeA == nodeB)
                {
                    continue;
                }

                var diff = Math.Abs(nodeA.val - nodeB.val);
                if (min > diff)
                {
                    min = diff;
                }
            }
        }

        return min;
    }
}