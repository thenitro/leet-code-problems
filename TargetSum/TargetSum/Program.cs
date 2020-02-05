using System;

namespace TargetSum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().FindTargetSumWays(new int[] {1, 1, 1, 1, 1}, 3));
        }
    }
}

public class Solution
{
    private int _result = 0;
    
    public int FindTargetSumWays(int[] nums, int S)
    {
        _result = 0;
        
        Dfs(nums, 0, 0, S);

        return _result;
    }

    private void Dfs(int[] nums, int startIndex, int currentSum, int targetSum)
    {
        if (startIndex >= nums.Length)
        {
            if (currentSum == targetSum)
            {
                _result++;
            }
            
            return;
        }

        Dfs(nums, startIndex + 1, currentSum + nums[startIndex], targetSum);
        Dfs(nums, startIndex + 1, currentSum - nums[startIndex], targetSum);
    }
}