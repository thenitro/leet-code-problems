using System;

namespace MinDepthOfBinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MinDepth(new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7),
                }
            }));
            
            Console.WriteLine(new Solution().MinDepth(new TreeNode(1)
            {
                left = new TreeNode(2)
            }));
            
            Console.WriteLine(new Solution().MinDepth(new TreeNode(3)));
            Console.WriteLine(new Solution().MinDepth(null));
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
    public int MinDepth(TreeNode root) {
        if (root == null)
        {
            return 0;
        }

        if (root.left != null && root.right != null)
        {
            return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;            
        } else if (root.left == null)
        {
            return MinDepth(root.right) + 1;
        }
        else if (root.right == null)
        {
            return MinDepth(root.left) + 1;
        }

        return 0;
    }
}