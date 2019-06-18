using System;
using System.Collections.Generic;

namespace ContainsDuplicate
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().ContainsDuplicate(new int[] {1, 2, 3, 1}));
            Console.WriteLine(false == new Solution().ContainsDuplicate(new int[] {1, 2, 3, 4}));
            Console.WriteLine(true == new Solution().ContainsDuplicate(new int[] {1, 1, 1, 3, 3, 4, 3, 2, 4, 2}));
        }
    }
}

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var set = new HashSet<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (set.Contains(nums[i]))
            {
                return true;
            }

            set.Add(nums[i]);
        }

        return false;
    }
}