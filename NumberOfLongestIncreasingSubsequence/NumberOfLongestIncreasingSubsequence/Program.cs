using System;

namespace NumberOfLongestIncreasingSubsequence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().FindNumberOfLIS(new []{ 1, 3, 5, 4, 7 }));
            Console.WriteLine(5 == new Solution().FindNumberOfLIS(new []{ 2, 2, 2, 2, 2 }));
        }
    }
}

public class Solution
{
    public int FindNumberOfLIS(int[] nums)
    {
        var N = nums.Length;
        if (N <= 1)
        {
            return N;
        }
        
        var lenghts = new int[N];
        var counts = new int[N];
        
        for (int i = 0; i < N; i++)
        {
            counts[i] = 1;
        }
        
        for (var j = 0; j < N; j++)
        {
            for (var i = 0; i < j; i++)
            {
                if (nums[i] < nums[j])
                {
                    if (lenghts[i] >= lenghts[j])
                    {
                        lenghts[j] = lenghts[i] + 1;
                        counts[j] = counts[i];
                    }
                    else if (lenghts[i] + 1 == lenghts[j])
                    {
                        counts[j] += counts[i];
                    }
                }
            }
        }

        var longest = 0;
        for (var i = 0; i < N; i++)
        {
            longest = Math.Max(lenghts[i], longest);
        }
        
        var ans = 0;
        for (int i = 0; i < N; i++)
        {
            if (lenghts[i] == longest)
            {
                ans += counts[i];
            }
        }

        return ans;
    }
}