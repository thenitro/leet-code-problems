using System;

namespace ProductOfArrayExceptSelf
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().ProductExceptSelf(new []{ 1, 2, 3, 4 })));
        }
    }

    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var N = nums.Length;

            var leftProduct = new int[N];
                leftProduct[0] = 1;
            
            var rightProduct = new int[N];
                rightProduct[N - 1] = 1;

            for (var i = 1; i < N; i++)
            {
                leftProduct[i] = leftProduct[i - 1] * nums[i - 1];
            }

            for (var i = N - 2; i >= 0; i--)
            {
                rightProduct[i] = rightProduct[i + 1] * nums[i + 1];
            }

            var result = new int[N];

            for (var i = 0; i < N; i++)
            {
                result[i] = leftProduct[i] * rightProduct[i];
            }

            return result;
        }
    }
}