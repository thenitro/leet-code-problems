using System;

namespace SubarrayProductLessThanK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(8 == new Solution().NumSubarrayProductLessThanK(new []{ 10, 5, 2, 6 }, 100));
            Console.WriteLine(18 == new Solution().NumSubarrayProductLessThanK(new []{ 10,9,10,4,3,8,3,3,6,2,10,10,9,3 }, 19));
        }
    }
}

public class Solution
{
    private int _result = 1;
    
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        if (k <= 1)
        {
            return 0;
        }
        
        var result = 0;
        var product = 1;
        var left = 0;
        
        for (var i = 0; i < nums.Length; i++)
        {
            product *= nums[i];
            while (product >= k)
            {
                product /= nums[left++];
            }

            result += i - left + 1;
        }

        return result;
    }
}