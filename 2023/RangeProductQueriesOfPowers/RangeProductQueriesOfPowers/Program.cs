using System;

namespace RangeProductQueriesOfPowers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().ProductQueries(15, new int[][] { new int[] { 0, 1 }, new[] { 2, 2 }, new[] { 0, 3 } })));
            Console.WriteLine(string.Join(",", new Solution().ProductQueries(2, new int[][] { new int[] { 0, 0 } })));
            Console.WriteLine(string.Join(",", new Solution().ProductQueries(13, new int[][] { new int[] { 1, 2 }, new []{1,1} })));
        }
    }
}