using System;
using System.Threading;

namespace ShortestUnsortedContinuousSubarray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().FindUnsortedSubarray(new[] {2, 6, 4, 8, 10, 9, 15}));
        }
    }
}

public class Solution
{
    public int FindUnsortedSubarray(int[] nums)
    {
        var length = nums.Length;
        var sortNums = new int[length];
        
        Array.Copy(nums, sortNums, length);
        Array.Sort(sortNums);

        var start = length;
        var end = 0;

        for (var i = 0; i < length; i++)
        {
            if (sortNums[i] != nums[i])
            {
                start = Math.Min(start, i);
                end = Math.Max(end, i);
            }
        }

        return end - start >= 0 ? end - start + 1 : 0;
    }
}