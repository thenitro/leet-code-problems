using System;
using System.Collections.Generic;

namespace CloneGraph
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            
            node1.neighbors.Add(node2);
            node2.neighbors.Add(node1);
            
            var cloned = new Solution().CloneGraph(node1);

            Console.WriteLine(cloned.neighbors[0].val);
            Console.WriteLine(cloned.neighbors[0].neighbors[0].val);

            new Solution().CloneGraph(null);
        }
    }
}

public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Solution
{
    public Node CloneGraph(Node node)
    {
        var cloned = new Dictionary<Node, Node>();

        return CloneHelper(node, cloned);
    }

    private Node CloneHelper(Node node, Dictionary<Node, Node> cloned)
    {
        if (node == null)
        {
            return null;
        }
        
        if (cloned.ContainsKey(node))
        {
            return cloned[node];
        }
        
        var clone = new Node(node.val);
        
        cloned[node] = clone;

        foreach (var neighbor in node.neighbors)
        {
            if (cloned.ContainsKey(neighbor))
            {
                clone.neighbors.Add(cloned[neighbor]);
            }
            else
            {
                clone.neighbors.Add(CloneHelper(neighbor, cloned));
            }
        }

        return clone;
    }
}