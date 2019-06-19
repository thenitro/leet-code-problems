using System;

namespace KthLargestElementInAnArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().FindKthLargest(new int[] { 3,2,1,5,6,4 }, 2));
            Console.WriteLine(4 == new Solution().FindKthLargest(new int[] { 3,2,3,1,2,4,5,5,6 }, 4));
        }
    }
}

public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        Array.Sort(nums);

        return nums[nums.Length - k];
    }
}