using System;

namespace LongestValidParenthese
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().LongestValidParentheses("(()"));
            Console.WriteLine(4 == new Solution().LongestValidParentheses(")()())"));
            Console.WriteLine(2 == new Solution().LongestValidParentheses("()(()"));
        }
    }
}

public class Solution
{
    public int LongestValidParentheses(string s)
    {
        var result = 0;
        var dp = new int[s.Length];
        
        for (var i = 1; i < dp.Length; i++)
        {
            if (s[i] == ')')
            {
                if (s[i - 1] == '(')
                {
                    dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                }
                else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                {
                    dp[i] = dp[i - 1] + ((i - dp[i - 1]) >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                }
            }

            result = Math.Max(result, dp[i]);
        }

        return result;
    }
}