using System;
using System.Collections.Generic;

namespace PathSum2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tree = new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(5),
                        right = new TreeNode(1)
                    }
                },
            };
            
            var result = new Solution().PathSum(tree, 22);
            
            foreach (var arr in result)
            {
                Console.WriteLine(string.Join(",", arr));                
            }
            
            var tree2 = new TreeNode(-2)
            {
                right = new TreeNode(-3)
            };
            
            
            var result2 = new Solution().PathSum(tree2, -5);
            
            foreach (var arr in result2)
            {
                Console.WriteLine(string.Join(",", arr));                
            }
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
    public IList<IList<int>> PathSum(TreeNode root, int sum) {
        var results = new List<IList<int>>();

        RecursiveHelper(results, new List<int>(), root, sum, 0);
        
        return results;
    }

    private void RecursiveHelper(List<IList<int>> results, List<int> subresults, TreeNode node, int sum, int currentSum)
    {
        if (node == null)
        {
            return;
        }
        
        subresults.Add(node.val);
        currentSum += node.val;
        
        if (node.left == null && node.right == null && currentSum == sum)
        {
            var copy = new List<int>(subresults);
            results.Add(copy);
        }
        else
        {
            RecursiveHelper(results, subresults, node.left, sum, currentSum);
            RecursiveHelper(results, subresults, node.right, sum, currentSum);
        }
        
        subresults.RemoveAt(subresults.Count - 1);
    }
}