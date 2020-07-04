using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LongestPalindromicSubsequence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().LongestPalindromeSubseq("bbbab"));
            Console.WriteLine(2 == new Solution().LongestPalindromeSubseq("cbbd"));
        }
    }
}

public class Solution
{
    public int LongestPalindromeSubseq(string s)
    {
        var dp = new int[s.Length, s.Length];

        for (var i = s.Length - 1; i >= 0; i--)
        {
            dp[i, i] = 1;

            for (var j = i + 1; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
        }
        
        return dp[0, s.Length - 1];
    }
}

public class SolutionSlow
{
    public int LongestPalindromeSubseq(string s)
    {
        var max = new int[1];
        
        Helper(s, true, 0, string.Empty, max); 
        Helper(s, false, 0, string.Empty, max);

        return max[0];
    }
    
    private void Helper(string s, bool take, int index, string current, int[] max)
    {
        if (index == s.Length)
        {
            return;
        }
        
        if (take)
        {
            current += s[index];
        }

        if (IsPalindrome(current))
        {
            max[0] = Math.Max(max[0], current.Length);
        }
        
        Helper(s, true, index + 1, current, max); 
        Helper(s, false, index + 1, current, max);
    }

    private bool IsPalindrome(string current)
    {
        if (current.Length == 1)
        {
            return true;
        }

        for (var i = 0; i < current.Length / 2; i++)
        {
            if (current[i] != current[current.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }
}