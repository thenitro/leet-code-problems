using System;
using System.Collections.Generic;

namespace BinaryTreeRightSideView
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().RightSideView(
                new TreeNode(1)
                {
                    left = new TreeNode(2)
                    {
                        right = new TreeNode(5)
                    },
                    right = new TreeNode(3)
                    {
                        right = new TreeNode(4)
                    }
                });
            
            Console.WriteLine(string.Join(",", result));
            
            var result2 = new Solution().RightSideView(
                new TreeNode(1)
                {
                    left = new TreeNode(2)
                    {
                        right = new TreeNode(5)
                        {
                            right = new TreeNode(7)
                        }
                    },
                    right = new TreeNode(3)
                    {
                        right = new TreeNode(4)
                    }
                });
            
            Console.WriteLine(string.Join(",", result2));
            
            var resultNull = new Solution().RightSideView(null);
            
            Console.WriteLine(string.Join(",", resultNull));
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
    public IList<int> RightSideView(TreeNode root)
    {
        var results = new List<int>();

        if (root == null)
        {
            return results;
        }

        var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

        var amountOfElements = 1;
        var counter = 0;

        while (queue.Count > 0)
        {
            for (var i = 0; i < amountOfElements; i++)
            {
                var node = queue.Dequeue();
                
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    counter++;
                }
                
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    counter++;
                }

                if (i == amountOfElements - 1)
                {
                    results.Add(node.val);
                }
            }

            amountOfElements = counter;
            counter = 0;
        }
        
        return results;
    }
}