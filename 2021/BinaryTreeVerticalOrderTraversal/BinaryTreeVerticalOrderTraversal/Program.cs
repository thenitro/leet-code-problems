using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeVerticalOrderTraversal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

public class Solution
{
    public IList<IList<int>> VerticalOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        
        if (root == null)
        {
            return result;
        }
        
        var dictionary = new Dictionary<int, List<int>>();

        var queue = new Queue<Tuple<int, TreeNode>>();
            queue.Enqueue(new Tuple<int, TreeNode>(0, root));

        while (queue.Count > 0)
        {
            var tuple = queue.Dequeue();

            var node = tuple.Item2;
            var column = tuple.Item1;
            
            var list = dictionary.ContainsKey(column) ? dictionary[column] : new List<int>();
                list.Add(node.val);

            dictionary[column] = list;

            if (node.left != null)
            {
                queue.Enqueue(new Tuple<int, TreeNode>(column - 1, node.left));
            }
            
            if (node.right != null)
            {
                queue.Enqueue(new Tuple<int, TreeNode>(column + 1, node.right));
            }
        }

        var min = dictionary.Keys.Min();
        var max = dictionary.Keys.Max();

        for (var i = min; i <= max; i++)
        {
            if (dictionary.ContainsKey(i))
            {
                result.Add(dictionary[i]);
            }
        }

        return result;
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