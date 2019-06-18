using System;
using System.Collections.Generic;

namespace ContainsDuplicateII
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().ContainsNearbyDuplicate(new []{1, 2, 3, 1}, 3));
            Console.WriteLine(true == new Solution().ContainsNearbyDuplicate(new []{1, 0, 1, 1}, 1));
            Console.WriteLine(false == new Solution().ContainsNearbyDuplicate(new []{1, 2, 3, 1, 2, 3}, 2));
        }
    }
}

public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var curr = nums[i];

            if (dict.ContainsKey(curr) && i - dict[curr] <= k)
            {
                return true;
            }

            dict[curr] = i;
        }

        return false;
    }
}