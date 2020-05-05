using System;

namespace MinimumCostToMergeStones
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(20 == new Solution().MergeStones(new[] {3, 2, 4, 1}, 2));
            Console.WriteLine(-1 == new Solution().MergeStones(new[] {3, 2, 4, 1}, 3));
            Console.WriteLine(25 == new Solution().MergeStones(new[] {3, 5, 1, 2, 6}, 3));
        }
    }
}

public class Solution
{
    public int MergeStones(int[] stones, int K)
    {
        var n = stones.Length;
        
        if ((n - 1) % (K - 1) > 0)
        {
            return -1;
        }

        var prefix = new int[n + 1];
        for (var i = 0; i < n; i++)
        {
            prefix[i + 1] = prefix[i] + stones[i];
        }

        var dp = new int[n, n];

        for (var m = K; m <= n; m++)
        {
            for (var i = 0; i + m <= n; i++)
            {
                var j = i + m - 1;

                dp[i, j] = int.MaxValue;

                for (var mid = i; mid < j; mid += K - 1)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i, mid] + dp[mid + 1, j]);
                }

                if ((j - i) % (K - 1) == 0)
                {
                    dp[i, j] += prefix[j + 1] - prefix[i];
                }
            }
        }

        return dp[0, n - 1];
    }
}