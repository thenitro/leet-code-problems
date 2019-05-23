using System;

namespace MergeTwoSortedLists
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintResult(new Solution().MergeTwoLists(
                new ListNode(1)
                {
                    next =  new ListNode(2)
                    {
                        next = new ListNode(4)
                    }
                },
                new ListNode(1)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                    }
                }
            ));
            
            PrintResult(new Solution().MergeTwoLists(
                null,
                new ListNode(0)
            ));
        }

        private static void PrintResult(ListNode node)
        {
            Console.WriteLine();
            
            var next = node;

            while (next != null)
            {
                Console.Write(next.val + " > ");
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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        var result = new ListNode(-1);
        var head = result;

        var next1 = l1;
        var next2 = l2;
        
        while (next1 != null || next2 != null)
        {
            ListNode nodeToApply = null;
            
            if (next1 == null && next2 != null)
            {
                nodeToApply = next2;
                next2 = next2.next;
            }

            if (next2 == null && next1 != null)
            {
                nodeToApply = next1;
                next1 = next1.next;
            }
            
            if (nodeToApply == null && next1.val >= next2.val)
            {
                nodeToApply = next2;
                next2 = next2.next;
            } 
            else if (nodeToApply == null && next1.val < next2.val)
            {                
                nodeToApply = next1;
                next1 = next1.next;
            }
            
            result.next = nodeToApply;
            result = result.next;            
        }

        return head.next;
    }
}