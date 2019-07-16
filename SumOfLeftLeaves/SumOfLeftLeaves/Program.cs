using System;
using System.Collections;
using System.Collections.Generic;

namespace SumOfLeftLeaves
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };
            
            Console.WriteLine(24 == new Solution().SumOfLeftLeaves(root));
        }
    }
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    public int SumOfLeftLeaves(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

        var sum = 0;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node == null)
            {
                continue;
            }

            if (node.left == null)
            {
                queue.Enqueue(node.right);
            }
            else
            {
                if (node.left.left == null && node.left.right == null)
                {
                    sum += node.left.val;
                }
                
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }
        
        return sum;
    }
}