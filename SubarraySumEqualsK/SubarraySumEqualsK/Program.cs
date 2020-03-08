using System;

namespace SubarraySumEqualsK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().SubarraySum(new[] {1, 1, 1}, 2));
            Console.WriteLine(1 == new Solution().SubarraySum(new[] {28, 54, 7, -70, 22, 65, -6}, 100));
            Console.WriteLine(55 == new Solution().SubarraySum(new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 0));
        }
    }
}

public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var sum = 0;

            for (var j = i; j < nums.Length; j++)
            {
                sum += nums[j];

                if (sum == k)
                {
                    result++;
                }
            }
        }

        return result;
    }
}