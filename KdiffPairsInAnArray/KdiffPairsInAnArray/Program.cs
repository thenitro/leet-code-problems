using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;

namespace KdiffPairsInAnArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().FindPairs(new []{ 3, 1, 4, 1, 5}, 2));
            Console.WriteLine(4 == new Solution().FindPairs(new []{ 1, 2, 3, 4, 5}, 1));
            Console.WriteLine(1 == new Solution().FindPairs(new []{ 1, 3, 1, 5, 4}, 0));
        }
    }
}

public class Solution
{
    public int FindPairs(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0 || k < 0)
        {
            return 0;
        }
        
        var dict = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            dict[num] = dict.ContainsKey(num) ? dict[num] + 1 : 1;
        }

        var count = 0;

        foreach (var kv in dict)
        {
            if (k == 0)
            {
                if (kv.Value >= 2)
                {
                    count++;
                }
            }
            else
            {
                if (dict.ContainsKey(kv.Key + k))
                {
                    count++;
                }
            }
        }

        return count;
    }
}

public class SolutionSlow2
{
    public int FindPairs(int[] nums, int k)
    {
        Array.Sort(nums);

        var count = 0;
        var set = new HashSet<int>();
        
        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                var a = nums[i];
                var b = nums[j];

                var key = a * nums.Length + b;

                if (set.Contains(key))
                {
                    continue;
                }
                else
                {
                    set.Add(key);
                }

                if (b - a == k)
                {
                    count++;
                }
            }
        }

        return count;
    }    
}

public class SolutionSlow
{
    public int FindPairs(int[] nums, int k)
    {
        var count = 0;

        var set = new HashSet<int>();
        
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = 0; j < nums.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                var min = Math.Min(nums[i], nums[j]);
                var max = Math.Max(nums[j], nums[i]);

                var key = min * nums.Length + max;
                
                if (set.Contains(key))
                {
                    continue;
                }
                else
                {
                    set.Add(key);
                }
                
                var diff = max - min;
                if (diff == k)
                {
                    count++;
                }
            }
        }

        return count;
    }
}