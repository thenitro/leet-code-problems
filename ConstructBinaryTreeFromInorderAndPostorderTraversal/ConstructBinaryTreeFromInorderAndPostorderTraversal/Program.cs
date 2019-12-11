using System;
using System.Collections.Generic;

namespace ConstructBinaryTreeFromInorderAndPostorderTraversal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new Solution().BuildTree(new[] {9, 3, 15, 20, 7}, new[] {9, 15, 7, 20, 3});
            Console.WriteLine();
            Inorder(tree);
            
            var tree1 = new Solution().BuildTree(new[] {2, 3, 1}, new[] {3, 2, 1});
            Console.WriteLine();
            Inorder(tree1);
            
            var treeEmpty = new Solution().BuildTree(new int[0], new int[0]);
            Inorder(treeEmpty);
        }

        public static void Inorder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            
            Inorder(root.left);
            Console.Write(root.val + " ");
            Inorder(root.right);
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
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        if (inorder.Length == 0 || postorder.Length == 0)
        {
            return null;
        }
        
        var map = new Dictionary<int, int>();
        for (var i = 0; i < inorder.Length; i++)
        {
            map.Add(inorder[i], i);
        }

        return BuildTreeHelper(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1, map);
    }

    private TreeNode BuildTreeHelper(int[] inorder, int inSi, int inEi, int[] postorder, int poSi, int poEi,
        Dictionary<int, int> map)
    {
        if (poSi > poEi || inSi > inEi)
        {
            return null;
        }
        
        var rootNode = new TreeNode(postorder[poEi]);
        var rootIndex = map[rootNode.val];

        rootNode.left = BuildTreeHelper(inorder, inSi, rootIndex - 1, postorder, poSi, poSi + rootIndex - inSi - 1, map);
        rootNode.right = BuildTreeHelper(inorder, rootIndex + 1, inorder.Length - 1, postorder, poSi + rootIndex - inSi, poEi - 1, map);

        return rootNode;
    }
}