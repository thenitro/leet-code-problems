using System;

namespace SmallestRangeI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(0 == new Solution().SmallestRangeI(new int[] { 1 }, 0));
            Console.WriteLine(6 == new Solution().SmallestRangeI(new int[] { 0, 10 }, 2));
            Console.WriteLine(0 == new Solution().SmallestRangeI(new int[] { 1, 3, 6 }, 3));
        }
    }
}

public class Solution {
    public int SmallestRangeI(int[] A, int K)
    {
        var min = A[0];
        var max = A[0];

        foreach (var x in A)
        {
            min = Math.Min(min, x);
            max = Math.Max(max, x);
        }

        return Math.Max(0, max - min - 2 * K);
    }
}