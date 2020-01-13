using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;

namespace Subsets
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().Subsets(new []{ 1, 2, 3});
            
            foreach (var subresult in result)
            {
                Console.WriteLine(string.Join(",", subresult));
            }
        }
    }
}

public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var results = new List<IList<int>>();
        Dfs(nums, new List<int>(), results, 0);
        return results;
    }

    private void Dfs(int[] numbers, IList<int> buffer, IList<IList<int>> results, int start)
    {
        results.Add(new List<int>(buffer));

        for (var i = start; i < numbers.Length; i++)
        {
            if (buffer.Contains(numbers[i]))
            {
                continue;
            }
            
            buffer.Add(numbers[i]);
            Dfs(numbers, buffer, results, i + 1);
            buffer.RemoveAt(buffer.Count - 1);
        }
    }
}