using System;
using System.Collections.Generic;
using System.Linq;

namespace FlattenMultilevelDoublyLinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var root = new Node()
            {
                val = 1,
                next = new Node()
                {
                    val = 2,
                    next = new Node()
                    {
                        val = 3,
                        next = new Node()
                        {
                            val = 4,
                            next = new Node()
                            {
                                val = 5,
                                next = new Node()
                                {
                                    val = 6,
                                }
                            }
                        },
                        child = new Node()
                        {
                            val = 7,
                            next = new Node()
                            {
                                val = 8,
                                next = new Node()
                                {
                                    next = new Node()
                                    {
                                        val = 9,
                                        next = new Node()
                                        {
                                            val = 10,
                                        }
                                    }
                                },
                                child = new Node()
                                {
                                    val = 11,
                                    next = new Node()
                                    {
                                        val = 12,
                                    }
                                }
                            }
                        }
                    }
                }
            };

            new Solution().Flatten(root);

            var prev = root;
            
            while (root != null)
            {
                Console.Write(root.val + " >");


                prev = root;
                root = root.next;
            }

            Console.WriteLine();
            
            while (prev != null)
            {
                Console.Write(prev.val + " < ");
                
                prev = prev.prev;
            }

            new Solution().Flatten(null);
        }
    }
}

public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}

public class Solution {
    public Node Flatten(Node head)
    {
        if (head == null)
        {
            return null;
        }
        
        var stack = new Queue<Node>();

        Dfs(head, stack);
        
        var node = stack.Dequeue();
        
        while (stack.Count > 0)
        {
            node.next = stack.Dequeue();
            node.next.prev = node;
            node.child = null;
            
            node = node.next;
        }
        
        return head;
    }

    private void Dfs(Node node, Queue<Node> stack)
    {
        if (node == null)
        {
            return;
        }

        stack.Enqueue(node);
        
        Dfs(node.child, stack);
        Dfs(node.next, stack);
    }
}