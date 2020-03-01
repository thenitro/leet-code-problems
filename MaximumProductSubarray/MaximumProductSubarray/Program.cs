using System;

namespace MaximumProductSubarray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(6 == new Solution().MaxProduct(new[] {2, 3, -2, 4}));
            Console.WriteLine(0 == new Solution().MaxProduct(new[] {-2, 0, -1}));
            Console.WriteLine(-2 == new Solution().MaxProduct(new[] { -2 }));
            Console.WriteLine(2 == new Solution().MaxProduct(new[] { 0, 2 }));
            Console.WriteLine(100 == new Solution().MaxProduct(new[] { 100, -100 }));
            Console.WriteLine(24 == new Solution().MaxProduct(new[] { -2,3,-4 }));
            Console.WriteLine(24 == new Solution().MaxProduct(new[] { 2,-5,-2,-4,3 }));
        }
    }
}

public class Solution
{
    public int MaxProduct(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return -1;
        } 
        
        var currentMax = nums[0];
        var currentMin = nums[0];
        var finalMax = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            var tmp = currentMax;
            
            currentMax = Math.Max(Math.Max(currentMax * nums[i], currentMin * nums[i]), nums[i]);
            currentMin = Math.Min(Math.Min(tmp * nums[i], currentMin * nums[i]), nums[i]);
            
            if (currentMax > finalMax)
            {
                finalMax = currentMax;
            }
        }
        
        return finalMax;
    }
}

public class SolutionDumb
{
    public int MaxProduct(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }
        
        if (nums.Length == 1)
        {
            return nums[0];
        }
        
        var n = nums.Length;
        var dp = new int[n, n];

        var max = int.MinValue;
        
        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                if (i == j)
                {
                    dp[i, j] = nums[i];
                }
                else
                {
                    dp[i, j] = dp[i, j - 1] * nums[j];
                }
                
                max = Math.Max(Math.Max(dp[i, j], nums[i]), max);
            }
        }

        return max;
    }
}