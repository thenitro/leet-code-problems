using System;

namespace MaximumSubarraySumWithOneDeletion
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().MaximumSum(new[] {1, -2, 0, 3}));
            Console.WriteLine(3 == new Solution().MaximumSum(new[] {1, -2, -2, 3}));
            Console.WriteLine(-1 == new Solution().MaximumSum(new[] {-1, -1, -1, -1}));
        }
    }
}

public class Solution
{
    public int MaximumSum(int[] arr)
    {
        var N = arr.Length;

        var oneDelete = 0;
        var noDelete = arr[0];

        var maxSum = arr[0];

        for (var i = 1; i < N; i++)
        {
            oneDelete = Math.Max(oneDelete + arr[i], noDelete);
            noDelete = Math.Max(noDelete + arr[i], arr[i]);

            maxSum = Math.Max(maxSum, Math.Max(oneDelete, noDelete));
        }

        return maxSum;
    }
}