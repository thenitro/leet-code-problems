using System;
using System.Collections.Generic;

namespace ContinuousSubarraySum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().CheckSubarraySum(new[] { 23, 2, 4, 6, 7 }, 6));
            Console.WriteLine(new Solution().CheckSubarraySum(new[] { 23, 2, 6, 4, 7 }, 6));
            Console.WriteLine(false == new Solution().CheckSubarraySum(new[] { 23, 2, 6, 4, 7 }, 13));
        }
    }
}

public class Solution
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        if (nums.Length <= 1)
        {
            return false;
        }

        var modList = new Dictionary<int, int>();
        var n = nums.Length;
        var partialSum = 0;

        for (var i = 0; i < n; i++)
        {
            partialSum = (partialSum + nums[i]) % k;

            if (i >= 1 && partialSum % k == 0)
            {
                return true;
            } 
            
            if (!modList.ContainsKey(partialSum))
            {
                modList[partialSum] = i;
            }
            else if (modList.ContainsKey(partialSum) && i >= modList[partialSum] + 2)
            {
                return true;
            }
        }

        return false;
    }
}