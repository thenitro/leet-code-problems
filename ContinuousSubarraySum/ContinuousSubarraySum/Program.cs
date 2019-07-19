using System;
using System.Collections.Generic;

namespace ContinuousSubarraySum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().CheckSubarraySum(new []{23, 2, 4, 6, 7}, 6));
            Console.WriteLine(true == new Solution().CheckSubarraySum(new []{23, 2, 6, 4, 7}, 6));
        }
    }
}

public class Solution {
    public bool CheckSubarraySum(int[] nums, int k)
    {
        var map = new Dictionary<int, int>();
            map.Add(0, -1);

        var runningSum = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            runningSum += nums[i];

            if (k != 0)
            {
                runningSum %= k;
            }

            if (map.ContainsKey(runningSum))
            {
                if (1 - map[runningSum] > 1)
                {
                    return true;
                }
            }
            else
            {
                map.Add(runningSum, i);
            }
        }

        return false;
    }
}