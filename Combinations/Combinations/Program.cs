using System;
using System.Collections.Generic;

namespace Combinations
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var results = new Solution().Combine(4, 2);

            foreach (var result in results)
            {
                foreach (var i in result)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var results = new List<IList<int>>();

        if (n <= 0 || k <= 0 || k > n)
        {
            return results;
        }

        Dfs(1, n, k, new List<int>(), results);

        return results;
    }

    private void Dfs(int start, int n, int k, List<int> list, List<IList<int>> results)
    {
        if (k == 0)
        {
            var result = new int[list.Count];
            
            list.CopyTo(result);
            results.Add(result);
            
            return;
        }

        for (var i = start; i <= n; i++)
        {
            list.Add(i);
            Dfs(i + 1, n, k - 1, list, results);
            list.RemoveAt(list.Count - 1);
        }
    }
}