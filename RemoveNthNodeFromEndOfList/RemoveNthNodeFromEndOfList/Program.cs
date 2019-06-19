using System;
using System.Data.SqlTypes;

namespace RemoveNthNodeFromEndOfList
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
            
            head = new Solution().RemoveNthFromEnd(head, 2);

            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
            
            Console.WriteLine();
            
            head = new ListNode(1);
            
            head = new Solution().RemoveNthFromEnd(head, 0);

            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
            
            Console.WriteLine();
            
            head = new ListNode(1);
            head = new Solution().RemoveNthFromEnd(head, 1);

            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
            
            Console.WriteLine();

            head = new ListNode(1)
            {
                next = new ListNode(2)
            };
            
            head = new Solution().RemoveNthFromEnd(head, 2);

            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
            
            Console.WriteLine();
            
            head = new ListNode(1)
            {
                next = new ListNode(2)
            };
            
            head = new Solution().RemoveNthFromEnd(head, 1);

            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
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
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var count = 0;
        var current = head;

        while (current != null)
        {
            count++;
            current = current.next;
        }

        count -= n;

        if (count > 0)
        {
            current = head;
            
            while (count > 1)
            {        
                current = current.next;
                count--;
            }
            
            current.next = current.next?.next;
        }
        else
        {
            head = head.next;
        }
        
        return head;
    }
}