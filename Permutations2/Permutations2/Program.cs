using System;
using System.Collections.Generic;

namespace Permutations2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().PermuteUnique(new[] {1, 1, 2});
            
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

public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var results = new List<IList<int>>();
        if (nums == null || nums.Length == 0)
        {
            return results;
        }
        
        Array.Sort(nums);
        Dfs(nums, new List<int>(), results, new bool[nums.Length]);

        return results;
    }

    private void Dfs(int[] nums, List<int> temp, List<IList<int>> results, bool[] visited)
    {
        if (nums.Length == temp.Count)
        {
            var result = new int[temp.Count];
            temp.CopyTo(result);
            results.Add(result);
            return;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (visited[i])
            {
                continue;
            }

            visited[i] = true;
            temp.Add(nums[i]);
            Dfs(nums, temp, results, visited);
            visited[i] = false;
            temp.RemoveAt(temp.Count - 1);

            while (i < nums.Length - 1 && nums[i] == nums[i + 1])
            {
                i++;
            } 
        }
    }
}