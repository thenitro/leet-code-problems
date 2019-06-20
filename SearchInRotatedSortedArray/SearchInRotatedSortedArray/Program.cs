using System;

namespace SearchInRotatedSortedArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().Search(new []{ 4,5,6,7,0,1,2 }, 0));
            Console.WriteLine(-1 == new Solution().Search(new []{ 4,5,6,7,0,1,2 }, 3));
        }
    }
}

public class Solution {
    public int Search(int[] nums, int target)
    {
        var lo = 0;
        var hi = nums.Length - 1;

        while (lo < hi)
        {
            var mid = (lo + hi) / 2;
            if (nums[mid] > nums[hi])
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid;
            }
        }

        var rot = lo;
        lo = 0;
        hi = nums.Length - 1;

        while (lo <= hi)
        {
            var mid = (lo + hi) / 2;
            var realMid = (mid + rot) % nums.Length;

            if (nums[realMid] == target) return realMid;
            if (nums[realMid] < target)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }
        }

        return -1;
    }
}