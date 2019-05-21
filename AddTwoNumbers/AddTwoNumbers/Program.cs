using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AddTwoNumbers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var listA = new ListNode(2)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(3)
                    { 
                    }
                }
            };
            
            var listB = new ListNode(5)
            {
                next = new ListNode(6)
                {
                    next = new ListNode(4)
                    { 
                    }
                }
            };
            
            var item = new Solution().AddTwoNumbers(listA, listB);
            while (item != null)
            {
                Console.WriteLine("result " + item.val);
                item = item.next;
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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode head = null;
        ListNode result = null;
        
        var p = l1;
        var q = l2;

        var carry = 0;
        
        while (p != null || q != null)
        {
            var num1 = p?.val ?? 0;
            var num2 = q?.val ?? 0;

            var summ = num1 + num2 + carry;
            
            carry = summ / 10;
            summ = summ % 10;
            
            if (result == null)
            {
                head = result = new ListNode(summ);
            }
            else
            {
                result.next = new ListNode(summ);
                result = result.next;
            }
            
            p = p?.next;
            q = q?.next;
        }

        if (carry > 0)
        {
            result.next = new ListNode(carry);
        }

        return head;
    }
}