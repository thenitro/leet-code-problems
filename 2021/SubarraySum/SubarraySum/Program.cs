using System;

namespace SubarraySum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().SubarraySum(new int[] { 1,1,1}, 2));
            Console.WriteLine(2 == new Solution().SubarraySum(new int[] { 1,2,3}, 3));
            Console.WriteLine(3 == new Solution().SubarraySum(new int[] { 1,-1,0}, 0));
        }
    }
}

public class Solution
{
    public int SubarraySum(int[] nums, int k)
    {
        var amount = 0;
        
        for (var i = 0; i < nums.Length; i++)
        {
            var sum = 0;

            for (var j = i; j < nums.Length; j++)
            {
                sum += nums[j];

                if (sum == k)
                {
                    amount++;
                }
            }
        }

        return amount;
    }
}