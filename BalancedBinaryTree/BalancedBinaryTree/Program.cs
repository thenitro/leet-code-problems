using System;

namespace BalancedBinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsBalanced(
                new TreeNode(3)
                {
                    left = new TreeNode(9),
                    right = new TreeNode(20)
                    {
                        left = new TreeNode(15),
                        right = new TreeNode(7),
                    },
                }));
            
            Console.WriteLine(new Solution().IsBalanced(
                new TreeNode(3)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(3)
                        {
                            left = new TreeNode(4),
                            right = new TreeNode(4),
                        },
                        right = new TreeNode(3),
                    },
                    right = new TreeNode(2),
                }));
                
            Console.WriteLine(new Solution().IsBalanced(
                new TreeNode(3)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(2)
                        {
                            left = new TreeNode(3),
                        },
                        right = new TreeNode(2)
                        {
                            right = new TreeNode(3)
                        }
                    },
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(4)
                        {
                            right = new TreeNode(4)
                        }
                    }
                }));
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
    public bool IsBalanced(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }
        
        return Test(root) != -1;
    }

    private int Test(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        var left = Test(root.left);
        var right = Test(root.right);

        if (left == -1 || right == -1 || Math.Abs(left - right) > 1)
        {
            return -1;
        }
        
        return 1 + Math.Max(left, right);
    }
}