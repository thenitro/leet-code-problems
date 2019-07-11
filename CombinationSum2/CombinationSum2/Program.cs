using System;
using System.Collections.Generic;

namespace CombinationSum2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().CombinationSum2(new[] {10, 1, 2, 7, 6, 1, 5}, 8);

            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine("-----");
            
            var result2 = new Solution().CombinationSum2(new[] {2, 5, 2, 1, 2}, 5);
            
            foreach (var i in result2)
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
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        var result = new List<IList<int>>();

        Array.Sort(candidates);
        
        Dfs(0, candidates, target, new List<int>(), result, new bool[candidates.Length]);
        
        return result;
    }

    private void Dfs(int index, int[] candidates, int target, List<int> temp, List<IList<int>> results, bool[] visited)
    {
        if (target == 0)
        {
            var result = new int[temp.Count];
            
            temp.CopyTo(result);
            results.Add(result);

            return;
        }

        for (var i = index; i < candidates.Length; i++)
        {
            if (visited[i])
            {
                continue;
            }
            
            var candidate = candidates[i];
            if (candidate > target)
            {
                break;
            }

            visited[i] = true;
            temp.Add(candidate);
            Dfs(i, candidates, target - candidate, temp, results, visited);
            visited[i] = false;
            temp.RemoveAt(temp.Count - 1);

            while (i < candidates.Length - 1 && candidates[i] == candidates[i + 1])
            {
                i++;
            }
        }
    }
}