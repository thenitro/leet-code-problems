using System;

namespace TargetSum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().FindTargetSumWays(new []{ 1, 1, 1, 1, 1 }, 3));
            Console.WriteLine(1 == new Solution().FindTargetSumWays(new []{ 1 }, 1));
        }
    }
}

public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        return SolutionHelper(nums, target, 0, 0);
    }

    private int SolutionHelper(int[] nums, int target, int currentSum, int index)
    {
        if (index == nums.Length)
        {
            if (target == currentSum)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        return SolutionHelper(nums, target, currentSum + nums[index], index + 1) +
               SolutionHelper(nums, target, currentSum - nums[index], index + 1);
    }
}