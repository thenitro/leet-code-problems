using System;

namespace MergeTwoBinaryTrees
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var t1 = new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(5)
                },
                right = new TreeNode(2)
            };

            var t2 = new TreeNode(2)
            {
                left = new TreeNode(1)
                {
                    right = new TreeNode(4)
                },
                right = new TreeNode(3)
                {
                    right = new TreeNode(7)
                }
            };

            var result = new Solution().MergeTrees(t1, t2);

            Console.WriteLine(result.val);
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
    public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
    {
        if (t1 == null && t2 == null)
        {
            return null;
        }

        var value1 = t1?.val ?? 0;
        var value2 = t2?.val ?? 0;
        
        var newNode = new TreeNode(value1 + value2);
        
            newNode.left = MergeTrees(t1?.left, t2?.left);
            newNode.right = MergeTrees(t1?.right, t2?.right);

        return newNode;
    }
}