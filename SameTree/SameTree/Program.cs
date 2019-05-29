using System;

namespace SameTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsSameTree(new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3)}, new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3)}));
            Console.WriteLine(new Solution().IsSameTree(new TreeNode(1) { left = new TreeNode(2)}, new TreeNode(1) { right = new TreeNode(2)}));
            Console.WriteLine(new Solution().IsSameTree(new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(1)}, new TreeNode(1) { right = new TreeNode(2), left = new TreeNode(1)}));
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
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null)
        {
            return true;
        }

        if (p == null && q != null)
        {
            return false;
        }

        if (p != null && q == null)
        {
            return false;
        }

        if (p.val != q.val)
        {
            return false;
        }

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}