using System;

namespace FreedomTrail
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().FindRotateSteps("godding", "gd"));
        }
    }
}

public class Solution
{
    public int FindRotateSteps(string ring, string key)
    {
        var n = ring.Length;
        var m = key.Length;

        var dp = new int[m + 1, n];

        for (var i = m - 1; i >= 0; i--)
        {
            for (var j = 0; j < n; j++)
            {
                dp[i, j] = int.MaxValue;

                for (var k = 0; k < n; k++)
                {
                    if (ring[k] == key[i])
                    {
                        var diff = Math.Abs(j - k);
                        var step = Math.Min(diff, n - diff);

                        dp[i, j] = Math.Min(dp[i, j], step + dp[i + 1, k]);
                    }
                }
            }
        }
        
        return dp[0, 0] + m;
    }
}