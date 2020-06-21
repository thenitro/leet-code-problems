using System;
using System.Collections.Generic;
using System.Linq;

namespace PartiotionEqualSubsetSum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().CanPartition(new int[] { 1, 5, 11, 5 }));
            Console.WriteLine(false == new Solution().CanPartition(new int[] { 1, 2, 3, 5 }));
            Console.WriteLine(false == new Solution().CanPartition(new int[] { 1, 2, 5 }));
        }
    }
}

public class Solution
{
    public bool CanPartition(int[] nums)
    {
        var sum = 0;

        foreach (var num in nums)    
        {
            sum += num;
        }

        if ((sum & 1) == 1)
        {
            return false;
        }

        sum /= 2;

        var n = nums.Length;
        var dp = new bool[n + 1, sum + 1];
            dp[0, 0] = true;

        for (var i = 1; i <= n; i++)
        {
            dp[i, 0] = true;
        }
        
        for (var j = 1; j <= sum; j++)
        {
            dp[0, j] = false;
        }

        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j <= sum; j++)
            {
                dp[i, j] = dp[i - 1, j];

                if (j >= nums[i - 1])
                {
                    dp[i, j] = dp[i, j] || dp[i - 1, j - nums[i - 1]];
                }
            }
        }

        return dp[n, sum];
    }
}

public class SolutionSlow
{
    public bool CanPartition(int[] nums)
    {
        var memo = new Dictionary<string, bool>();
        return CanPartitionHelper(nums, nums.Sum(), 0, 0, memo);
    }

    private bool CanPartitionHelper(int[] nums, int sumA, int sumB, int index, Dictionary<string, bool> memo)
    {
        if (index == nums.Length - 1)
        {
            return sumA == sumB;
        }

        var key = sumA + "_" + sumB;

        if (memo.ContainsKey(key))
        {
            return memo[key];
        }

        var currentNum = nums[index];
        index++;

        memo[key] = CanPartitionHelper(nums, sumA - currentNum, sumB + currentNum, index, memo) ||
                    CanPartitionHelper(nums, sumA, sumB, index, memo);
        
        return memo[key];
    }
}