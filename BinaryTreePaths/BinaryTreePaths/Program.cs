using System;
using System.Collections.Generic;

namespace BinaryTreePaths
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new Solution().BinaryTreePaths(new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(5)
                },
                right = new TreeNode(3),
            });

            foreach (var i in list)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine("-----");
            
            new Solution().BinaryTreePaths(null);
            
            var list2 = new Solution().BinaryTreePaths(new TreeNode(1));
            
            foreach (var i in list2)
            {
                Console.Write(i + " ");
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
    public IList<string> BinaryTreePaths(TreeNode root) {
        var result = new List<string>();

        if (root == null)
        {
            return result;
        }

        FindPaths(root, root.val.ToString(), result);
        
        return result;
    }

    private void FindPaths(TreeNode root, string path, List<string> paths)
    {
        if (root == null)
        {
            return;
        }
        
        if (root.left == null && root.right == null) 
        {    
            if (!paths.Contains(path))
            {
                paths.Add(path);
            }

            return;
        }

        if (root.left != null)
        {
            FindPaths(root.left, path + "->" + root.left.val, paths);            
        }
        
        if (root.right != null)
        {
            FindPaths(root.right, path + "->" + root.right.val, paths);
        }
    }
}