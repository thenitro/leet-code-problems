using System;

namespace LongestIncreasingSubsequence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().LengthOfLIS(new[] {10, 9, 2, 5, 3, 7, 101, 18}));
            Console.WriteLine(4 == new Solution().LengthOfLIS(new[] {2, 5, 3, 7, 101, 18}));
            Console.WriteLine(4 == new Solution().LengthOfLIS(new[] {10, 9, 2, 5, 3, 7, 101}));
            Console.WriteLine(1 == new Solution().LengthOfLIS(new[] {2, 2}));
            Console.WriteLine(3 == new Solution().LengthOfLIS(new[] {4, 10, 4, 3, 8, 9}));
            Console.WriteLine(6 == new Solution().LengthOfLIS(new[] {1, 3, 6, 7, 9, 4, 10, 5, 6}));
            Console.WriteLine(0 == new Solution().LengthOfLIS(new int[0]));
            Console.WriteLine(0 == new Solution().LengthOfLIS(null));
        }
    }
}

public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }
        
        var memo = new int[nums.Length];
            memo[0] = 1;

        var result = 1;

        for (var i = 1; i < memo.Length; i++)
        {
            var value = 0;

            for (var j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    value = Math.Max(value, memo[j]);
                }
            }

            memo[i] = value + 1;
            result = Math.Max(result, memo[i]);
        }
        
        return result;
    }
}