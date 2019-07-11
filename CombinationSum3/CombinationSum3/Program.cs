using System;
using System.Collections.Generic;
using System.Linq;

namespace CombinationSum3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var results = new Solution().CombinationSum3(3, 7);
            foreach (var i in results)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                
                Console.WriteLine();
            }
            Console.WriteLine("-----");
            
            var results2 = new Solution().CombinationSum3(3, 9);
            foreach (var i in results2)
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
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var results = new List<IList<int>>();
        if (k <= 0 || n <= 0 || k > n)
        {
            return results;
        }
        
        var combinations = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

        Dfs(0, combinations, k, n, new List<int>(), results, new bool[combinations.Length]);

        return results;
    }

    private void Dfs(int startIndex, int[] combinations, int k, int n, List<int> temp, List<IList<int>> results, bool[] visited)
    {
        if (k == 0)
        {
            if (temp.Sum() == n)
            {
                var result = new int[temp.Count];
                temp.CopyTo(result);
            
                results.Add(result);
            }
            
            return;
        }

        for (var i = startIndex; i < combinations.Length; i++)
        {
            var current = combinations[i];
            if (visited[i])
            {
                continue;
            }

            visited[i] = true;
            temp.Add(current);
            Dfs(i, combinations, k - 1, n, temp, results, visited);
            visited[i] = false;
            temp.RemoveAt(temp.Count - 1);
        }
    }
}