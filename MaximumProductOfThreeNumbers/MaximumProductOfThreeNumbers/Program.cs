using System;

namespace MaximumProductOfThreeNumbers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(6 == new Solution().MaximumProduct(new[] {1, 2, 3}));
            Console.WriteLine(24 == new Solution().MaximumProduct(new[] {1, 2, 3, 4}));
            Console.WriteLine(24 == new Solution().MaximumProduct(new[] {1, 2, -3, -4}));
        }
    }
}

public class Solution
{
    public int MaximumProduct(int[] nums)
    {
        var min1 = int.MaxValue;
        var min2 = int.MaxValue;

        var max1 = int.MinValue;
        var max2 = int.MinValue;
        var max3 = int.MinValue;

        for (var i = 0; i < nums.Length; i++)
        {
            var n = nums[i];

            if (n <= min1)
            {
                min2 = min1;
                min1 = n;
            }
            else if (n <= min2)
            {
                min2 = n;
            }

            if (n >= max1)
            {
                max3 = max2;
                max2 = max1;
                max1 = n;
            } 
            else if (n >= max2)
            {
                max3 = max2;
                max2 = n;
            }
            else if (n >= max3)
            {
                max3 = n;
            }            
        }

        return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
    }
}