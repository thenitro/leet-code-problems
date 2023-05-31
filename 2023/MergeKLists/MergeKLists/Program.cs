using System;

namespace MergeKLists
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().MergeKLists(
                new[]
                {
                    new ListNode(1, new ListNode(4, new ListNode(5))),
                    new ListNode(1, new ListNode(3, new ListNode(4))),
                    new ListNode(2, new ListNode(6)),
                });
            
            PrintResult(result);

            new Solution().MergeKLists(new ListNode[] { });
            new Solution().MergeKLists(new ListNode[] { null });
        }

        private static void PrintResult(ListNode node)
        {
            var current = node;

            while (current != null)
            {
                Console.Write($"{current.val}->");
                current = current.next;
            }

            Console.WriteLine();
        }
    }
}