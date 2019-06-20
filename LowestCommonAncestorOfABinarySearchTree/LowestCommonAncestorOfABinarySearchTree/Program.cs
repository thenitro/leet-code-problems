using System;
using System.Collections.Generic;

namespace LowestCommonAncestorOfABinarySearchTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var four = new TreeNode(4)
            {
                left = new TreeNode(3),
                right = new TreeNode(5)
            };

            var two = new TreeNode(2)
            {
                left = new TreeNode(0),
                right = four
            };

            var eight = new TreeNode(8)
            {
                left = new TreeNode(7),
                right = new TreeNode(9),
            };

            var root = new TreeNode(6)
            {
                left = two,
                right = eight
            };

            Console.WriteLine(6 == new Solution().LowestCommonAncestor(root, two, eight).val);
            Console.WriteLine(2 == new Solution().LowestCommonAncestor(root, two, four).val);
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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var pathToP = FindPath(root, p);
        var pathToQ = FindPath(root, q);

        TreeNode prev = null;
        
        while (pathToP.Count > 0 && pathToQ.Count > 0)
        {
            var nodeP = pathToP.Dequeue();
            var nodeQ = pathToQ.Dequeue();
            
            if (nodeP != nodeQ)
            {
                return prev;
            }

            prev = nodeP;
        }

        return prev;
    }

    private Queue<TreeNode> FindPath(TreeNode root, TreeNode target)
    {
        var node = root;
        var path = new Queue<TreeNode>();
            path.Enqueue(root);

        while (node != null)
        {
            if (target.val == node.val)
            {
                break;
            }

            if (target.val > node.val)
            {
                path.Enqueue(node.right);
                node = node.right;
            }
            else
            {
                path.Enqueue(node.left);
                node = node.left;
            }
        }

        return path;
    }
}