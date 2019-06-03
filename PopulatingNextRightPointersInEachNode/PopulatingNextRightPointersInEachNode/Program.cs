using System;
using System.Collections.Generic;

namespace PopulatingNextRightPointersInEachNode
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var nodes = new Node()
            {
                val = 1,
                left = new Node()
                {
                    val = 2,
                    left = new Node()
                    {
                        val = 4
                    },
                    right = new Node()
                    {
                        val = 5
                    }
                },
                right = new Node()
                {
                    val = 3,
                    
                    right = new Node()
                    {
                        val = 7,
                    }
                },
            };
            
            new Solution().Connect(nodes);
            
            PrintNode(nodes);
        }

        private static void PrintNode(Node node)
        {
            if (node == null)
            {
                return;
            }
            
            Console.WriteLine(node.val + " -> " + (node.next?.val ?? -1));
            
            PrintNode(node.left);
            PrintNode(node.right);
        }
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node()
        {
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }

    }

    public class Solution {
            public Node Connect(Node root)
            {
                if (root == null)
                {
                    return root;
                }
                
                var queue = new Queue<Node>();
                    queue.Enqueue(root);

                var count = 1;
                    
                while (queue.Count > 0)
                {
                    var currentCount = 0;
                    
                    while (count > 0)
                    {
                        var current = queue.Dequeue();
                        var next = count > 1 ? queue.Peek() : null;
                        
                        current.next = next;

                        if (current.left != null)
                        {
                            queue.Enqueue(current.left);
                            currentCount++;
                        }

                        if (current.right != null)
                        {
                            queue.Enqueue(current.right);
                            currentCount++;
                        }

                        count--;
                    }

                    count = currentCount;
                }

                return root;
            }
        }
}

