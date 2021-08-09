using System.Collections.Generic;

namespace LowestCommonAncestorOfBinaryTree3
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
    public Node LowestCommonAncestor(Node p, Node q)
    {
        var set = new HashSet<Node>();
        
        while (p != null)
        {
            set.Add(p);
            p = p.parent;
        }
        
        while (q != null)
        {
            if (set.Contains(q))
            {
                return q;
            }

            set.Add(q);
            q = q.parent;
        }

        return null;
    }
}

public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}