using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace BinaryTreeInorderTraversal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().InorderTraversal(new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    left = new TreeNode(3)
                }
            });
            
            Console.WriteLine(string.Join(", ", result));
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
    public IList<int> InorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        var stack = new Stack<TreeNode>();

        while (root != null || stack.Count > 0)
        {
            while (root != null)
            {
                stack.Push(root);
                root = root.left;
            }

            root = stack.Pop();
            result.Add(root.val);
            root = root.right;
        }

        return result;
    }
}

public class Solution2 {
    public IList<int> InorderTraversal(TreeNode root)
    {
        var result = new List<int>();

        Traverse(root, result);

        return result;
    }

    private void Traverse(TreeNode node, List<int> result)
    {
        if (node == null)
        {
            return;
        }
        
        Traverse(node.left, result);
        result.Add(node.val);
        Traverse(node.right, result);
    } 
}