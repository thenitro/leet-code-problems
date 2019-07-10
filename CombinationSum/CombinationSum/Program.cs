using System;
using System.Collections.Generic;

namespace CombinationSum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().CombinationSum(new []{ 2, 3, 6, 7}, 7);

            Console.WriteLine("result ");
            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                
                Console.WriteLine();
            }
            Console.WriteLine("-----");
            
            var result2 = new Solution().CombinationSum(new []{ 2, 3, 5}, 8);            
            
            Console.WriteLine("result ");
            foreach (var i in result2)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                
                Console.WriteLine();
            }
            Console.WriteLine("-----");
        }
    }
}

public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var results = new List<IList<int>>();
        
        if (candidates == null || candidates.Length == 0)
        {
            return results;
        }
        
        Array.Sort(candidates);
        
        var combination = new List<int>();
        
        Dfs(results, combination, candidates, target, 0);

        return results;
    }

    private void Dfs(IList<IList<int>> results, List<int> combination, int[] candidates, int target, int startIndex)
    {
        if (target == 0)
        {
            var combinationCopy = new int[combination.Count];
            combination.CopyTo(combinationCopy);            
            results.Add(combinationCopy);
            return;
        }

        for (var i = startIndex; i < candidates.Length; i++)
        {
            if (candidates[i] > target)
            {
                break;
            }
            
            combination.Add(candidates[i]);
            Dfs(results, combination, candidates, target - candidates[i], i);
            combination.RemoveAt(combination.Count - 1);
        }
    }
}