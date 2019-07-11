using System;
using System.Collections.Generic;

namespace Permutations
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().Permute(new []{ 1, 2, 3});

            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                
                Console.WriteLine();
            }
        }
    }
}

public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var results = new List<IList<int>>();
        if (nums == null || nums.Length == 0)
        {
            return results;
        }

        Dfs(nums, new List<int>(), results);
        
        return results;
    }

    private void Dfs(int[] nums, List<int> temp, List<IList<int>> results)
    {
        if (temp.Count == nums.Length)
        {
            var result = new int[temp.Count];
            temp.CopyTo(result);
            results.Add(result);
            return;
        }
        
        for (var i = 0; i < nums.Length; i++)
        {
            if (temp.Contains(nums[i]))
            {
                continue;    
            }
            
            temp.Add(nums[i]);
            Dfs(nums, temp, results);
            temp.RemoveAt(temp.Count - 1);
        }
    }
}