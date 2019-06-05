using System;

namespace PathSum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().HasPathSum(new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    right = new TreeNode(11)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        right = new TreeNode(1)
                    }
                }
            }, 22));
            
            Console.WriteLine(new Solution().HasPathSum(null, 0));
            
            Console.WriteLine(new Solution().HasPathSum(new TreeNode(1)
            {
                left = new TreeNode(2)
            }, 1));
            
            Console.WriteLine(new Solution().HasPathSum(new TreeNode(-2)
            {
                right = new TreeNode(-3)
            }, -5));
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
    private int _calculation = 0;
    
    public bool HasPathSum(TreeNode root, int sum)
    {
        return Calculate(root, 0, sum);
    }

    private bool Calculate(TreeNode root, int calculation, int sum)
    {
        if (root == null)
        {
            return false;
        }

        calculation += root.val;

        if (root.left == null && root.right == null)
        {
            if (calculation == sum)
            {
                return true;
            }
        }

        return Calculate(root.left, calculation, sum) || Calculate(root.right, calculation, sum);
    }
}