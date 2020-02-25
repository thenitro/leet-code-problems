using System;

namespace RussianDollEnvelopes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().MaxEnvelopes(
                                  new[]
                                  {
                                      new[] {5, 4},
                                      new[] {6, 4},
                                      new[] {6, 7},
                                      new[] {2, 3},
                                  }));
            
            Console.WriteLine(4 == new Solution().MaxEnvelopes(
                                  new[]
                                  {
                                      new[] {4, 5},
                                      new[] {4, 6},
                                      new[] {6, 7},
                                      new[] {2, 3},
                                      new[] {1, 1},
                                  }));
            
            Console.WriteLine(4 == new Solution().MaxEnvelopes(
                                  new[]
                                  {
                                      new[] {4, 5},
                                      new[] {4, 6},
                                      new[] {6, 7},
                                      new[] {2, 3},
                                      new[] {1, 1},
                                      new[] {1, 1},
                                  }));
        }
    }
}

public class Solution
{
    public int MaxEnvelopes(int[][] envelopes)
    {
        Array.Sort(envelopes, (ints, ints1) => ints[0] - ints1[0]);

        var N = envelopes.Length;
        var dp = new int[N];
        var currentMax = 0;

        for (int i = 0; i < N; i++)
        {
            dp[i] = 1;
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (envelopes[i][0] > envelopes[j][0] && 
                    envelopes[i][1] > envelopes[j][1])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }

            currentMax = Math.Max(dp[i], currentMax);
        }

        return currentMax;
    }
}