using System;

namespace NonOverlappingIntervals
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 ==
                              new Solution().EraseOverlapIntervals(new[]
                                  { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 1, 3 } }));
        }
    }
}