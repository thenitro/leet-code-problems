using System;
using System.Collections.Generic;

namespace BinaryTreeRightSideView
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    right = new TreeNode(4)
                },
            };

            Console.WriteLine(string.Join(",", new Solution().RightSideView(root)));
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();
            
            if (root == null)
            {
                return result;
            }
            
            var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

            var count = 1;
            var newCount = 0; 
            
            while (queue.Count > 0)
            {
                count--;
                
                var node = queue.Dequeue();
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                    newCount++;
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                    newCount++;
                }

                if (count == 0)
                {
                    result.Add(node.val);
                    count = newCount;
                    newCount = 0;
                }
            }
            
            return result;
        }
    }
}