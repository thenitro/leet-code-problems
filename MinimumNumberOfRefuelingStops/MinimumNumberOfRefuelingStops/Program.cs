using System;

namespace MinimumNumberOfRefuelingStops
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().MinRefuelStops(100, 10,
                                  new[] {new[] {10, 60}, new[] {20, 30}, new[] {30, 30}, new[] {60, 40}}));
            Console.WriteLine(0 == new Solution().MinRefuelStops(1, 1, new int[][] { }));
            Console.WriteLine(-1 == new Solution().MinRefuelStops(100, 1, new[] {new[] {10, 100}}));
            Console.WriteLine(3 == new Solution().MinRefuelStops(100, 25, new[] {new[] {25, 25}, new[] {50, 25}, new[] {75, 25}}));
        }
    }
}

public class Solution
{
    public int MinRefuelStops(int target, int startFuel, int[][] stations)
    {
        var N = stations.Length;
        var dp = new long[N + 1];
            dp[0] = startFuel;

        for (var i = 0; i < N; i++)
        {
            for (var t = i; t >= 0; t--)
            {
                if (dp[t] >= stations[i][0])
                {
                    dp[t + 1] = Math.Max(dp[t + 1], dp[t] +  stations[i][1]);
                }
            }
        }

        for (var i = 0; i <= N; i++)
        {
            if (dp[i] >= target)
            {
                return i;
            }
        }

        return -1;
    }
}