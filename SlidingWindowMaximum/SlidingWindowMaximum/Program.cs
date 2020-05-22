using System;
using System.Collections.Generic;

namespace SlidingWindowMaximum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //3,3,5,5,6,7
            Console.WriteLine(string.Join(",", new Solution().MaxSlidingWindow(new []{ 1,3,-1,-3,5,3,6,7 }, 3)));
            
            //7, 4
            Console.WriteLine(string.Join(",", new Solution().MaxSlidingWindow(new []{ 7, 2, 4 }, 2)));
        }
    }
}

public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var result = new List<int>();
        var queue = new List<int>();

        var last = 0;
        var first = 1 - k;
        
        for (; last < nums.Length; last++, first++)
        {
            while (queue.Count != 0 && nums[last] > queue[queue.Count - 1])
            {
                queue.RemoveAt(queue.Count - 1);
            }
            
            queue.Add(nums[last]);

            if (first < 0)
            {
                continue;
            }

            result.Add(queue[0]);

            if (nums[first] == queue[0])
            {
                queue.RemoveAt(0);
            }
        }
        
        return result.ToArray();
    }
}