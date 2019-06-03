using System;
using System.Collections.Generic;

namespace VerticalOrderTraversalOfABinaryTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result1 = new Solution().VerticalTraversal(
                new TreeNode(3)
                {
                    left = new TreeNode(9),
                    right = new TreeNode(20)
                    {
                        left = new TreeNode(15),
                        right = new TreeNode(7)
                    }
                });

            Print(result1);
            
            var result2 = new Solution().VerticalTraversal(
                new TreeNode(1)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(4),
                        right = new TreeNode(5),
                    },
                    right = new TreeNode(3)
                    {
                        left = new TreeNode(6),
                        right = new TreeNode(7)
                    }
                });

            Print(result2);
        }

        private static void Print(IList<IList<int>> list)
        {
            foreach (var sublist in list)
            {
                Console.WriteLine();

                foreach (var i in sublist)
                {
                    Console.Write(i + " ");
                }
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
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        var locations = new List<Location>();
        DFS(root, 0, 0, locations);
        locations.Sort((a, b) =>
        {
            if (a.X != b.X)
            {
                return a.X.CompareTo(b.X);
            }
            else if (a.Y != b.Y)
            {
                return a.Y.CompareTo(b.Y);
            }
            else
            {
                return a.Value.CompareTo(b.Value);
            }
        });
        
        var result = new List<IList<int>>();
            result.Add(new List<int>());

        var prev = locations[0].X;
        foreach (var location in locations)
        {
            if (location.X != prev)
            {
                prev = location.X;
                result.Add(new List<int>());
            }
            
            result[result.Count - 1].Add(location.Value);
        }
        
        return result;
    }

    private void DFS(TreeNode root, int x, int y, List<Location> list)
    {
        if (root == null)
        {
            return;
        }
        
        list.Add(new Location { X = x, Y = y, Value = root.val});
        
        DFS(root.left, x-1, y+1, list);
        DFS(root.right, x+1, y+1, list);
    }

    private class Location
    {
        public int X;
        public int Y;
        public int Value;
    }
}