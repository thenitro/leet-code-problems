using System;
using System.Collections.Generic;
using System.Net.Security;

namespace TreeSumClosest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().ThreeSumClosest(new int[] { -1, 2, 1, -4 }, 1));
            Console.WriteLine(3 == new Solution().ThreeSumClosest(new int[] { 0, 1, 2}, 3));
            Console.WriteLine(3 == new Solution().ThreeSumClosest(new int[] { 1, 1, 1, 1}, 0));
            Console.WriteLine(0 == new Solution().ThreeSumClosest(new int[] { 0, 2, 1, -3}, 1));
        }
    }
}

public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);

        var results = new List<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var a = nums[i];
            var l = i + 1;
            var r = nums.Length - 1;

            while (l < r)
            {
                var b = nums[l];
                var c = nums[r];

                var sum = a + b + c;

                if (sum > target)
                {
                    r--;
                } else
                {
                    l++;
                }
                
                results.Add(sum);
            }
        }

        results.Sort();

        if (results.Count > 0)
        {
            var minDiff = int.MaxValue;
            var index = results.Count - 1;
            
            for (var i = 0; i < results.Count; i++)
            {
                var diff = Math.Abs(target - results[i]);
                
                if (diff < minDiff)
                {
                    minDiff = diff;
                    index = i;
                }
            }

            return results[index];
        }
        
        return 0;
    }
}