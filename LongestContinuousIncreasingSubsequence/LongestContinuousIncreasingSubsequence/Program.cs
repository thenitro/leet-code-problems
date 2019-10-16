using System;

namespace LongestContinuousIncreasingSubsequence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(0 == new Solution().FindLengthOfLCIS(new int[0]));
            Console.WriteLine(1 == new Solution().FindLengthOfLCIS(new[] { 1 }));
            Console.WriteLine(4 == new Solution().FindLengthOfLCIS(new[] {1, 3, 5, 7}));
            Console.WriteLine(3 == new Solution().FindLengthOfLCIS(new[] {1, 3, 5, 4, 7}));
            Console.WriteLine(1 == new Solution().FindLengthOfLCIS(new[] {2, 2, 2, 2, 2}));
        }
    }
}

public class Solution
{
    public int FindLengthOfLCIS(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        
        var max = 1;
        var count = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] - nums[i - 1] > 0)
            {
                count++;
            }
            else
            {
                if (count > max)
                {
                    max = count;
                }
                
                count = 1;
            }
        }
        
        if (count > max)
        {
            max = count;
        }
        
        return max;
    }
}