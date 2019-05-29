using System;
using System.Collections.Generic;

namespace SymmetricTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsSymmetric(
                new TreeNode(1)
                {
                    left =  new TreeNode(2)
                    {
                        left = new TreeNode(3),
                        right = new TreeNode(4)
                    }, 
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(4),
                        right = new TreeNode(3)
                    }
                }));
            
            Console.WriteLine(new Solution().IsSymmetric(
                new TreeNode(1)
                {
                    left =  new TreeNode(2)
                    {
                        right = new TreeNode(3)
                    }, 
                    right = new TreeNode(2)
                    {
                        right = new TreeNode(3)
                    }
                }));
            
            Console.WriteLine(new Solution().IsSymmetric(
                new TreeNode(3)
                {
                    left =  new TreeNode(4)
                    {
                        left = new TreeNode(5)
                        {
                            left = new TreeNode(6)
                        }
                    }, 
                    right = new TreeNode(4)
                    {
                        right = new TreeNode(5)
                        {
                            right = new TreeNode(6)
                        }
                    }
                }));
            
            Console.WriteLine(new Solution().IsSymmetric(
                new TreeNode(3)
                {
                    left =  new TreeNode(2)
                    {
                        left = new TreeNode(3)
                        {
                            left = new TreeNode(4),
                            right = new TreeNode(5)
                            {
                                left = new TreeNode(8),
                                right = new TreeNode(9),
                            }
                        }
                    }, 
                    right = new TreeNode(2)
                    {
                        right = new TreeNode(3)
                        {
                            left = new TreeNode(5),
                            right = new TreeNode(4)
                            {
                                left = new TreeNode(9),
                                right = new TreeNode(8),
                            }
                        }
                    }
                }));
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
    public bool IsSymmetric(TreeNode root)
    {
        var queue = new Queue<TreeNode>();
        
        queue.Enqueue(root);
        queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            var n1 = queue.Dequeue();
            var n2 = queue.Dequeue();

            if (n1 == null && n2 == null) continue;
            if (n1 == null || n2 == null) return false;
            if (n1.val != n2.val) return false;
            
            queue.Enqueue(n1.left);
            queue.Enqueue(n2.right);
            queue.Enqueue(n1.right);
            queue.Enqueue(n2.left);
        }

        return true;
    }
}