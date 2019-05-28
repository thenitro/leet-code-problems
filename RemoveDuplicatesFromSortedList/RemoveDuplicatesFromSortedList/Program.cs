using System;
using System.Data.Odbc;

namespace RemoveDuplicatesFromSortedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintList(new Solution().DeleteDuplicates(null));
            PrintList(new Solution().DeleteDuplicates(new ListNode(1) { next = new ListNode(1)}));
            PrintList(new Solution().DeleteDuplicates(new ListNode(1) { next = new ListNode(1) { next = new ListNode(1) }}));
            PrintList(new Solution().DeleteDuplicates(new ListNode(1) ));
            PrintList(new Solution().DeleteDuplicates(new ListNode(1){ next = new ListNode(2) }));
            PrintList(new Solution().DeleteDuplicates(new ListNode(1) { next = new ListNode(1){ next = new ListNode(2) }}));
            PrintList(new Solution().DeleteDuplicates(new ListNode(1) { next = new ListNode(1){ next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(3) }} }}));
        }

        private static void PrintList(ListNode head)
        {
            Console.WriteLine();

            var next = head;
            
            while (next != null)
            {
                Console.Write(next.val + " ");
                next = next.next;
            }
        }
    }
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null)
        {
            return null;
        }
        
        var prev = head;
        var current = prev.next;

        while (current != null)
        {
            if (current.val == prev.val)
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