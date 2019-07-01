using System;

namespace SwapNodesInPairs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var head = new Solution().SwapPairs(new ListNode(1)
                {next = new ListNode(2) {next = new ListNode(3) {next = new ListNode(4)}}});

            while (head != null)
            {
                Console.Write(head.val + " ");
                
                head = head.next;
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
    public ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        var next = head.next;

        head.next = SwapPairs(head.next.next);
        next.next = head;

        return next;
    }
}