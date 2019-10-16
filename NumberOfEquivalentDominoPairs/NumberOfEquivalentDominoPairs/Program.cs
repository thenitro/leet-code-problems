using System;
using System.Collections.Generic;

namespace NumberOfEquivalentDominoPairs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().NumEquivDominoPairs(
                                  new[]
                                  {
                                      new[] {1, 2},
                                      new[] {2, 1},
                                      new[] {3, 4},
                                      new[] {5, 6},
                                  }));
            
            Console.WriteLine(3 == new Solution().NumEquivDominoPairs(
                                  new[]
                                  {
                                      new[] {1, 2},
                                      new[] {1, 2},
                                      new[] {1, 1},
                                      new[] {1, 2},
                                      new[] {2, 2},
                                  }));
        }
    }
}

public class Solution
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        var counter = 0;
        var dict = new Dictionary<int, int>();

        foreach (var domino in dominoes)
        {
            var left = Math.Min(domino[0], domino[1]);
            var right = Math.Max(domino[0], domino[1]);

            var index = left * 9 + right;

            dict[index] = dict.ContainsKey(index) ? dict[index] + 1 : 1;
        }

        foreach (var kv in dict)
        {
            counter += kv.Value * (kv.Value - 1) / 2;
        }

        return counter;
    }
}