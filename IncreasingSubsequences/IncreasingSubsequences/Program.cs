using System;
using System.Collections.Generic;

namespace IncreasingSubsequences
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().FindSubsequences(new []{ 4, 6, 7, 7});

            foreach (var subresult in result)
            {
                Console.WriteLine(string.Join(", ", subresult));
            }
        }
    }
}

public class Solution
{
    public IList<IList<int>> FindSubsequences(int[] nums)
    {
        var results = new List<IList<int>>();
        Dfs(nums, 0, int.MinValue, new List<int>(), results);
        return results;
    }

    private void Dfs(int[] nums, int startIndex, int prev, List<int> tmp, List<IList<int>> results)
    {
        if (tmp.Count > 1)
        {
            results.Add(new List<int>(tmp));
        }

        var used = new HashSet<int>();
        
        for (var i = startIndex; i < nums.Length; i++)
        {
            if (used.Contains(nums[i]) || prev > nums[i])
            {
                continue;
            }
            
            tmp.Add(nums[i]);
            used.Add(nums[i]);
            Dfs(nums, i + 1, nums[i], tmp, results);
            tmp.RemoveAt(tmp.Count - 1);
        }
    }
}