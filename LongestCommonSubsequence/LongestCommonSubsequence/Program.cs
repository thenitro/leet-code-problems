using System;

namespace LongestCommonSubsequence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().LongestCommonSubsequence("abcde", "ace"));
            Console.WriteLine(3 == new Solution().LongestCommonSubsequence("abc", "abc"));
            Console.WriteLine(0 == new Solution().LongestCommonSubsequence("abc", "def"));
            Console.WriteLine(1 == new Solution().LongestCommonSubsequence("bsbininm", "jmjkbkjkv"));
        }
    }
}

public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var dp = new int[text1.Length + 1, text2.Length + 1];

        for (var i = 1; i <= text1.Length; i++)
        {
            for (var j = 1; j <= text2.Length; j++)
            {
                dp[i, j] = text1[i - 1] == text2[j - 1] ? dp[i - 1, j - 1] + 1 : Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        return dp[text1.Length, text2.Length];
    }
}