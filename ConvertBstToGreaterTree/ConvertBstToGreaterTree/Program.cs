using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConvertBstToGreaterTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new TreeNode(5)
            {
                left = new TreeNode(2),
                right = new TreeNode(13)
            };

            new Solution().ConvertBST(tree);

            InOrderPrint(tree);
        }

        private static void InOrderPrint(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            
            InOrderPrint(root.left);
            Console.Write(root.val + " ");
            InOrderPrint(root.right);
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
    private int _currentValue = 0;
    
    public TreeNode ConvertBST(TreeNode root)
    {
        InOrderHelper(root);
        return root;
    }

    private void InOrderHelper(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        
        InOrderHelper(root.right);
        
        var newValue = _currentValue + root.val;
        root.val = newValue;
        _currentValue = newValue;
        
        InOrderHelper(root.left);
    }
}