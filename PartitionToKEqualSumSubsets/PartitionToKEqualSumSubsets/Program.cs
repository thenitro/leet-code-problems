using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PartitionToKEqualSumSubsets
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().CanPartitionKSubsets(new []{ 4, 3, 2, 3, 5, 2, 1 }, 4));
            Console.WriteLine(false == new Solution().CanPartitionKSubsets(new []{ 4, 3, 2, 3, 5, 2 }, 4));
            Console.WriteLine(true == new Solution().CanPartitionKSubsets(new []{ 10,10,10,7,7,7,7,7,7,6,6,6 }, 3));
            
        }
    }
}

public class Solution
{
    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        var sum = nums.Sum();
        if (sum % k != 0)
        {
            return false;
        }
        
        var targetSum = sum / k;
        
        return Helper(nums, new HashSet<int>(), 0, k, 0, 0, targetSum);
    }

    private bool Helper(int[] nums, HashSet<int> visited, int startIndex, int k, int currentSum, int currentNum, int target)
    {
        if (k == 1)
        {
            return true;
        }

        if (currentSum == target && currentNum > 0)
        {
            return Helper(nums, visited, 0, k - 1, 0, 0, target);
        }

        for (var i = startIndex; i < nums.Length; i++)
        {
            if (visited.Contains(i))
            {
                continue;
            }

            visited.Add(i);
            if (Helper(nums, visited, i + 1, k, currentSum + nums[i], currentNum++, target))
            {
                return true;
            }
            visited.Remove(i);
        }

        return false;
    }
}