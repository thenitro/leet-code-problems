using System;

namespace FindPeakElement
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().FindPeakElement(new[] {1, 2, 3, 1}));
            Console.WriteLine(5 == new Solution().FindPeakElement(new[] {1, 2, 1, 3, 5, 6, 4}));
            Console.WriteLine(5 == new Solution().FindPeakElement(new[] {7, 2, 1, 3, 5, 6, 4}));
            Console.WriteLine(6 == new Solution().FindPeakElement(new[] {3, 3, 1, 3, 5, 6, 9}));
        }
    }
}

public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        var l = 0;
        var r = nums.Length - 1;

        while (l < r)
        {
            var mid = (l + r) / 2;

            if (nums[mid] > nums[mid + 1])
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }
        }

        return l;
    }
}

public class SolutionLinear
{
    public int FindPeakElement(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            if ((i == 0 || nums[i] > nums[i - 1]) && (i == nums.Length - 1 || nums[i] > nums[i + 1]))
            {
                return i;
            }
        }

        return -1;
    }
}