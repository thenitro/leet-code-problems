using System;

namespace SearchInsertPosition
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().SearchInsert(new []{ 1, 3, 5, 6}, 5));
            Console.WriteLine(1 == new Solution().SearchInsert(new []{ 1, 3, 5, 6}, 2));
            Console.WriteLine(4 == new Solution().SearchInsert(new []{ 1, 3, 5, 6}, 7));
            Console.WriteLine(0 == new Solution().SearchInsert(new []{ 1, 3, 5, 6}, 0));
        }
    }
}

public class Solution {
    public int SearchInsert(int[] nums, int target)
    {
        var l = 0;
        var r = nums.Length;

        while (r > l)
        {
            var middle = (l + r) / 2;

            if (target > nums[middle])
            {
                l = middle + 1;
            }
            else if (target < nums[middle])
            {
                r = middle;
            }
            else
            {
                return middle;
            }
        }

        return l;
    }
}