using System.Collections.Generic;
using System.Linq;

namespace CopyListWithRandomPointer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public class Solution
    {
        public Node CopyRandomList(Node head)
        {
            return GetNode(head, new Dictionary<Node, Node>());
        }

        private Node GetNode(Node source, Dictionary<Node, Node> constructedNodes)
        {
            if (source == null)
            {
                return null;
            }
            
            if (constructedNodes.ContainsKey(source))
            {
                return constructedNodes[source];
            }

            var newNode = new Node(source.val);
            
            constructedNodes.Add(source, newNode);

            newNode.next = GetNode(source.next, constructedNodes);
            newNode.random = GetNode(source.random, constructedNodes);

            return newNode;
        }
    }
}