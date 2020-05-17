using System;
using System.Collections.Generic;

namespace HowManyNumbersAreSmallerThanTheCurrentNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().SmallerNumbersThanCurrent(new[] {8, 1, 2, 2, 3})));
            Console.WriteLine(string.Join(",", new Solution().SmallerNumbersThanCurrent(new[] {6, 5, 4, 8})));
            Console.WriteLine(string.Join(",", new Solution().SmallerNumbersThanCurrent(new[] {7, 7, 7, 7})));
        }
    }
}

public class Solution
{
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        var N = nums.Length;
        var sorted = new int[N];

        Array.Copy(nums, sorted, N);
        Array.Sort(sorted);

        var dict = new Dictionary<int, int>();

        for (var i = 0; i < N; i++)
        {
            if (dict.ContainsKey(sorted[i]))
            {
                continue;
            }

            dict[sorted[i]] = i;
        }

        var result = new int[N];

        for (var i = 0; i < N; i++)
        {
            result[i] = dict[nums[i]];
        }

        return result;
    }
}