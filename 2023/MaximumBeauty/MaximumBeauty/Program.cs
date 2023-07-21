using System;

namespace MaximumBeauty
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().MaximumBeauty(new[] { 4, 6, 1, 2 }, 2));
            Console.WriteLine(1 == new Solution().MaximumBeauty(new[] { 4, 6, 1, 2 }, 0));
            Console.WriteLine(4 == new Solution().MaximumBeauty(new[] { 1, 1, 1, 1 }, 10));
            Console.WriteLine(2 == new Solution().MaximumBeauty(new[] { 49, 26 }, 12));
        }
    }
}