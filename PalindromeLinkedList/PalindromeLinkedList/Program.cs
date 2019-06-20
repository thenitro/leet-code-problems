using System;

namespace PalindromeLinkedList
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(false == new Solution().IsPalindrome(new ListNode(1) { next = new ListNode(2)}));
            Console.WriteLine(true == new Solution().IsPalindrome(new ListNode(1) { next = new ListNode(2) {next = new ListNode(2) { next = new ListNode(1)}}}));
            Console.WriteLine(true == new Solution().IsPalindrome(new ListNode(1) { next = new ListNode(2) {next = new ListNode(3) { next = new ListNode(2) {next = new ListNode(1)}}}}));
        }
    }
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution {
    public bool IsPalindrome(ListNode head)
    {
        var count = 0;
        var current = head;

        while (current != null)
        {
            count++;
            current = current.next;
        }

        var isEven = count % 2 == 0;
        var middle = count / 2 + (isEven ? 0 : 1);

        count = 0;
        current = head;

        var list = new ListNode[isEven ? middle : middle + 1];

        while (current != null)
        {
            if (count >= middle)
            {
                if (list[count - middle].val != current.val)
                {
                    return false;
                }
            }
            else
            {
                list[middle - count - 1] = current;
            }
            
            count++;
            
            if (isEven == false && count == middle)
            {
                count++;                
            }
            
            current = current.next;
        }
        
        return true;
    }
}