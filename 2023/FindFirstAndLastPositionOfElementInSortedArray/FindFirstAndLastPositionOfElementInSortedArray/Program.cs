using System;

namespace FindFirstAndLastPositionOfElementInSortedArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8)));
            Console.WriteLine(string.Join(",", new Solution().SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6)));
            Console.WriteLine(string.Join(",", new Solution().SearchRange(new int[] {  }, 0)));
            Console.WriteLine(string.Join(",", new Solution().SearchRange(new int[] { 2, 2 }, 3)));
            Console.WriteLine(string.Join(",", new Solution().SearchRange(new int[] { 1, 3 }, 1)));
        }
    }
}