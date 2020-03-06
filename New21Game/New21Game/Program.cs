using System;

namespace New21Game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1.0 == new Solution().New21Game(10, 1, 10));
            Console.WriteLine(0.6 == new Solution().New21Game(6, 1, 10));
            Console.WriteLine(0.732777787068608 == new Solution().New21Game(21, 17, 10));
        }
    }
}

public class Solution
{
    public double New21Game(int N, int K, int W)
    {
        var dp = new double[N + W + 1];
        for (var k = K; k <= N; k++)
        {
            dp[k] = 1.0;
        }

        var S = (double)Math.Min(N - K + 1, W);

        for (var k = K - 1; k >= 0; k--)
        {
            dp[k] = S / W;
            S += dp[k] - dp[k + W];
        }

        return dp[0];
    }
}