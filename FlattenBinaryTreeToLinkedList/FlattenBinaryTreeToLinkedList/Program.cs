using System;
using System.Security.Cryptography;
using FlattenBinaryTreeToLinkedList;

namespace FlattenBinaryTreeToLinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },
                right = new TreeNode(5)
                {
                    right = new TreeNode(6)
                }
            };

            new Solution().Flatten(root);
            
            Print(root);
        }

        public static void Print(TreeNode node)
        {
            Console.WriteLine();
            
            while (node != null)
            {
                Console.Write(node.val + " > ");
                
                node = node.right;
            }
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
    public void Flatten(TreeNode root)
    {
        PostTraversal(root, null);
    }

    private TreeNode PostTraversal(TreeNode node, TreeNode prev)
    {
        if (node != null)
        {
            prev = PostTraversal(node.right, prev);
            prev = PostTraversal(node.left, prev);

            node.right = prev;
            node.left = null;

            prev = node;
        }

        return prev;
    }
}