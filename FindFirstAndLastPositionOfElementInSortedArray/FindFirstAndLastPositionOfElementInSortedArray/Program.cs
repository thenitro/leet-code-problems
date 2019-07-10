using System;

namespace FindFirstAndLastPositionOfElementInSortedArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().SearchRange(new []{ 5, 7, 7, 8, 8, 10}, 8);
            Console.WriteLine(result[0] == 3 && result[1] == 4);
            
            result = new Solution().SearchRange(new []{ 5, 7, 7, 8, 10}, 8);
            Console.WriteLine(result[0] == 3 && result[1] == 3);
            
            result = new Solution().SearchRange(new []{ 5, 7, 7, 8, 8, 10}, 6);
            Console.WriteLine(result[0] == -1 && result[1] == -1);
            
            result = new Solution().SearchRange(new []{ 1 }, 1);
            Console.WriteLine(result[0] == 0 && result[1] == 0);
            
            result = new Solution().SearchRange(new []{ 1 }, 2);
            Console.WriteLine(result[0] == -1 && result[1] == -1);
            
            result = new Solution().SearchRange(new []{ 1, 4 }, 4);
            Console.WriteLine(result[0] == 1 && result[1] == 1);
        }
    }
}

public class Solution {
    public int[] SearchRange(int[] nums, int target)
    {
        if (nums.Length == 1 && nums[0] == target)
        {
            return new[] {0, 0};
        }
        
        var lo = 0;
        var hi = nums.Length;

        while (lo < hi)
        {
            var middle = (lo + hi) / 2;
            
            if (target == nums[middle])
            {
                var left = middle;

                while (left > 0 && nums[left - 1] == target)
                {
                    left--;
                }
                
                var right = middle;

                while (right < nums.Length - 1 && nums[right + 1] == target)
                {
                    right++;
                }
                
                return new[] { left, right };
            } 
            
            if (target > nums[middle])
            {
                lo = middle + 1;
            }
            else
            {
                hi = middle;
            }
        }

        return new int[] { -1, -1 };
    }
}