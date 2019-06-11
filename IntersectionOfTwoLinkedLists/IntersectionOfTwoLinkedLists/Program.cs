using System;

namespace IntersectionOfTwoLinkedLists
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var intersection = new ListNode(8)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(5)
                }
            };
            
            var nodeA = new ListNode(4)
            {
                next = new ListNode(1)
                {
                    next = intersection
                }
            };
            
            var nodeB = new ListNode(5)
            {
                next = new ListNode(0)
                {
                    next = new ListNode(1)
                    {
                        next = intersection
                    }
                }
            };
            
            Console.WriteLine(intersection == new Solution().GetIntersectionNode(nodeA, nodeB));
        }
    }
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        var nextA = headA;
        
        while (nextA != null)
        {
            var nextB = headB;
            
            while (nextB != null)
            {
                if (nextA == nextB)
                {
                    return nextA;
                }
                
                nextB = nextB.next;
            }
            
            nextA = nextA.next;
        }

        return null;
    }
}