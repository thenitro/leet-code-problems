using System;

namespace CoinChange
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().CoinChange(new []{ 1, 2, 5 }, 11));
            Console.WriteLine(-1 == new Solution().CoinChange(new []{ 2 }, 3));
        }
    }
}

public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        var max = amount + 1;
        var dp = new int[max];

        for (var i = 0; i < max; i++)
        {
            dp[i] = max;
        }

        dp[0] = 0;

        for (var i = 1; i < max; i++)
        {
            for (var j = 0; j < coins.Length; j++)
            {
                if (coins[j] <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }
        }

        return dp[amount] > amount ? - 1 : dp[amount];
    }
}