using System;

namespace CountDifferentPalindromicSubsequences
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(6 == new Solution().CountPalindromicSubsequences("bccb"));
            Console.WriteLine(104860361 ==
                              new Solution().CountPalindromicSubsequences(
                                  "abcdabcdabcdabcdabcdabcdabcdabcddcbadcbadcbadcbadcbadcbadcbadcba"));
        }
    }
}

public class Solution
{
    private long MOD = 1000000007;
    
    public int CountPalindromicSubsequences(string S)
    {
        var len = S.Length;
        var dp = new int[len, len];

        for (var i = 0; i < len; i++)
        {
            dp[i, i] = 1;
        }

        for (var i = 1; i < len; i++)
        {
            var beg = 0;
            
            for (var end = i; end < len; end++, beg++)
            {
                if (S[beg] == S[end])
                {
                    dp[beg, end] = 2 * dp[beg + 1, end - 1];

                    var leftIdx = beg + 1;
                    var rightIdx = end - 1;
                    var ch = S[beg];

                    while (leftIdx <= rightIdx && ch != S[leftIdx])
                    {
                        leftIdx++;
                    }
                    
                    while (leftIdx <= rightIdx && ch != S[rightIdx])
                    {
                        rightIdx--;
                    }

                    if (leftIdx > rightIdx)
                    {
                        dp[beg, end] += 2;
                    }
                    else if (leftIdx == rightIdx)
                    {
                        dp[beg, end] += 1;
                    }
                    else
                    {
                        dp[beg, end] -= dp[leftIdx + 1, rightIdx - 1];
                    }
                }
                else
                {
                    dp[beg, end] = dp[beg, end - 1] + dp[beg + 1, end] - dp[beg + 1, end - 1];
                }
                
                dp[beg, end] = (int) ((dp[beg, end] + MOD) % MOD);
            }
        }

        return dp[0, len - 1];
    }
}