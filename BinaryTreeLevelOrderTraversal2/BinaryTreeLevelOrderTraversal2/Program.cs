using System;
using System.Collections.Generic;

namespace BinaryTreeLevelOrderTraversal2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };
            
            foreach (var sublist in new Solution().LevelOrderBottom(tree))
            {
                foreach (var i in sublist)
                {
                    Console.Write(i + " ");
                }
                
                Console.WriteLine();
            }

            new Solution().LevelOrderBottom(null);
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
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        var result = new List<IList<int>>();
        
        if (root == null)
        {
            return result;
        }
        
        var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

        var size = 1;
            
        while (queue.Count > 0)
        {
            var subResult = new List<int>();
            var currentSize = size;
            
            size = 0;

            for (var i = 0; i < currentSize; i++)
            {
                var node = queue.Dequeue();
                
                subResult.Add(node.val);

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    size++;
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    size++;
                }
            }
            
            result.Add(subResult);
        }
        
        result.Reverse();

        return result;
    }
}