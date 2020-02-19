using System;

namespace MinimumAsciiDeleteSumForTwoStrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(231 == new Solution().MinimumDeleteSum("sea", "eat"));
            Console.WriteLine(403 == new Solution().MinimumDeleteSum("delete", "leet"));
        }
    }
}

public class Solution
{
    public int MinimumDeleteSum(string s1, string s2)
    {
        var dp = new int[s1.Length + 1, s2.Length + 1];

        for (var i = s1.Length - 1; i >= 0; i--)
        {
            dp[i, s2.Length] = dp[i + 1, s2.Length] + (int)s1[i];
        }
        
        for (var j = s2.Length - 1; j >= 0; j--)
        {
            dp[s1.Length, j] = dp[s1.Length, j + 1] + (int)s2[j];
        }

        for (var i = s1.Length - 1; i >= 0; i--)
        {
            for (var j = s2.Length - 1; j >= 0; j--)
            {
                if (s1[i] == s2[j])
                {
                    dp[i, j] = dp[i + 1, j + 1];
                }
                else
                {
                    dp[i, j] = Math.Min(dp[i + 1, j] + (int)s1[i], 
                                        dp[i, j + 1] + (int)s2[j]);
                }
            }
        }

        return dp[0, 0];
    }
}