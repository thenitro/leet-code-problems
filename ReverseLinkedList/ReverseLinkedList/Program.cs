using System;
using System.Collections.Generic;

namespace ReverseLinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };
            
            var newHead = new Solution().ReverseList(head);

            while (newHead != null)
            {
                Console.Write(newHead.val + " ");
                newHead = newHead.next;
            }
            Console.WriteLine();
            
            head = new ListNode(1);
            newHead = new Solution().ReverseList(head);
            
            while (newHead != null)
            {
                Console.Write(newHead.val + " ");
                newHead = newHead.next;
            }
            Console.WriteLine();
            
            head = new ListNode(1)
            {
                next = new ListNode(2)
            };
            newHead = new Solution().ReverseList(head);
            
            while (newHead != null)
            {
                Console.Write(newHead.val + " ");
                newHead = newHead.next;
            }
            Console.WriteLine();
            
            newHead = new Solution().ReverseList(null);
            
            while (newHead != null)
            {
                Console.Write(newHead.val + " ");
                newHead = newHead.next;
            }
            Console.WriteLine();
        }
    }
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public ListNode ReverseList(ListNode head) {
        if (head == null)
        {
            return null;
        }

        var queue = new Stack<ListNode>();
        
        var current = head;
        while (current.next != null)
        {
            queue.Push(current);
            current = current.next;
        }
        
        var newHead = current;

        while (queue.Count > 0)
        {
            current.next = queue.Pop();
            current = current.next;
        }
        
        current.next = null;

        return newHead;
    }
}