using System;

namespace FindMinimumInRotatedSortedArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().FindMin(new []{ 3,4,5,1,2 }));
            Console.WriteLine(0 == new Solution().FindMin(new []{ 4,5,6,7,0,1,2 }));
            Console.WriteLine(1 == new Solution().FindMin(new []{ 1,2 }));
        }
    }
}

public class Solution {
    public int FindMin(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        var left = 0;
        var right = nums.Length - 1;

        if (nums[right] > nums[0])
        {
            return nums[0];
        }

        while (right >= left)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] > nums[mid + 1])
            {
                return nums[mid + 1];
            }

            if (nums[mid - 1] > nums[mid])
            {
                return nums[mid];
            }

            if (nums[mid] > nums[0])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}