using System.Collections.Generic;

namespace RangeSumOfBst
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

public class Solution
{
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        var sum = 0;

        var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node == null)
            {
                continue;
            }
            
            if (node.val >= low &&
                node.val <= high)
            {
                sum += node.val;
            }

            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        return sum;
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