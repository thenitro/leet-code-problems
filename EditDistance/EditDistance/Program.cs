using System;

namespace EditDistance
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().MinDistance("horse", "ros"));
            Console.WriteLine(5 == new Solution().MinDistance("intention", "execution"));
        }
    }
}

public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        var dp = new int[word1.Length + 1, word2.Length + 2];

        for (var i = 0; i <= word1.Length; i++)
        {
            dp[i, 0] = i;
        }
        
        for (var j = 0; j <= word2.Length; j++)
        {
            dp[0, j] = j;
        }

        for (var i = 1; i <= word1.Length; i++)
        {
            for (var j = 1; j <= word2.Length; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Min(
                            dp[i - 1, j],
                            Math.Min(dp[i - 1, j - 1], dp[i, j - 1])
                        ) + 1;
                }
            }
        }

        return dp[word1.Length, word2.Length];
    }
}