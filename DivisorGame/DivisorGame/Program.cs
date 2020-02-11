using System;

namespace DivisorGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().DivisorGame(2));
            Console.WriteLine(false == new Solution().DivisorGame(3));
        }
    }
}

public class Solution 
{
    public bool DivisorGame(int N)
    {
        var dp = new bool[N + 1];

        for (var n = 2; n <= N; n++)
        {
            for (var j = 1; j < n; j++)
            {
                if (n % j == 0)
                {
                    dp[n] = dp[n] || !dp[n - j];
                }
            }
        }

        return dp[N];
    }
}