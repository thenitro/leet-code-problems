using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PathSum3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new TreeNode(10)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(3),
                        right = new TreeNode(-2),
                    },
                    right = new TreeNode(2)
                    {
                        right = new TreeNode(1)
                    },
                },
                right = new TreeNode(-3)
                {
                    right = new TreeNode(11)
                },
            };
            
            Console.WriteLine(3 == new Solution().PathSum(tree, 8));
            
            var tree2 = new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    right = new TreeNode(3)
                    {
                        right = new TreeNode(4)
                        {
                            right = new TreeNode(5)
                        }
                    }
                }
            };
            
            Console.WriteLine(2 == new Solution().PathSum(tree2, 3));
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
    public int PathSum(TreeNode root, int sum)
    {
        if (root == null)
        {
            return 0;
        }

        return PathSumHelper(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
    }

    private int PathSumHelper(TreeNode node, int sum)
    {
        if (node == null)
        {
            return 0;
        }

        return (node.val == sum ? 1 : 0) + 
               PathSumHelper(node.left, sum - node.val) +
               PathSumHelper(node.right, sum - node.val);
    }
}