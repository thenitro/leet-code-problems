using System;
using System.Collections.Generic;
using System.Linq;

namespace CombinationSumIV
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(7 == new Solution().CombinationSum4(new int[] {1, 2, 3}, 4));
            Console.WriteLine(39882198 == new Solution().CombinationSum4(new int[] {4, 2, 1}, 32));
            Console.WriteLine(89 == new Solution().CombinationSum4(new int[] {1, 2}, 10));
        }
    }
}

public class Solution
{
    private int[] _memo;
    
    public int CombinationSum4(int[] nums, int target)
    {
        _memo = new int[target + 1];
        for (var i = 0; i < _memo.Length; i++)
        {
            _memo[i] = -1;
        }

        _memo[0] = 1;

        return Dp(nums, target);
    }

    private int Dp(int[] nums, int target)
    {
        if (_memo[target] != -1)
        {
            return _memo[target];
        }

        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (target >= nums[i])
            {
                result += Dp(nums, target - nums[i]);
            }
        }

        _memo[target] = result;
        
        return result;
    }
}