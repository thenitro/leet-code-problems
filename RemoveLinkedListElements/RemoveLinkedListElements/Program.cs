using System;
using System.Diagnostics.Eventing.Reader;

namespace RemoveLinkedListElements
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var listNode = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(6)
                    {
                        next = new ListNode(3)
                        {
                            next = new ListNode(4)
                            {
                                next = new ListNode(5)
                                {
                                    next = new ListNode(6)
                                }
                            }
                        }
                    }
                }
            };

            listNode = new Solution().RemoveElements(listNode, 6);

            var next = listNode;

            while (next != null)
            {
                Console.Write(next.val + " ");
                next = next.next;
            }
            
            Console.WriteLine();
            
            listNode = new Solution().RemoveElements(null, 1);
            
            listNode = new ListNode(1)
            {
                next = new ListNode(1)
            };

            listNode = new Solution().RemoveElements(listNode, 1);

            next = listNode;

            while (next != null)
            {
                Console.Write(next.val + " ");
                next = next.next;
            }
            
            Console.WriteLine();
            
            listNode = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(1)
                    }
                }
            };

            listNode = new Solution().RemoveElements(listNode, 2);

            next = listNode;

            while (next != null)
            {
                Console.Write(next.val + " ");
                next = next.next;
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
    public ListNode RemoveElements(ListNode head, int val)
    {
        while (head != null && head.val == val)
        {
            head = head.next;                
        }
        
        if (head == null) return null;

        var prev = head;
        var current = head.next;
        
        while (current != null)
        {
            if (current.val == val)
            {
                prev.next = current.next;
            }
            else
            {
                prev = current;
            }
            
            current = current.next;
        }

        return head;
    }
}