using System;
using System.Collections.Generic;

namespace LinkedListCycle
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var head = new ListNode(3);
            var cycle = new ListNode(2);

            head.next = cycle;
            cycle.next = new ListNode(0)
            {
                next = new ListNode(-4)
                {
                    next = cycle,
                }
            };
            
            Console.WriteLine(true == new Solution().HasCycle(head));
        }
    }
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) {
        val = x;
        next = null;
    }
}

public class Solution
{
    public bool HasCycle(ListNode head)
    {
        var set = new HashSet<ListNode>();
        var next = head;

        while (next != null)
        {
            if (set.Contains(next))
            {
                return true;
            }

            set.Add(next);
            next = next.next;
        }

        return false;
    }
}