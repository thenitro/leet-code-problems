using System;

namespace NumberOfMusicPlaylists
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(6 == new Solution().NumMusicPlaylists(3, 3, 1));
            Console.WriteLine(6 == new Solution().NumMusicPlaylists(2, 3, 0));
            Console.WriteLine(2 == new Solution().NumMusicPlaylists(2, 3, 1));
        }
    }
}

public class Solution
{
    public int NumMusicPlaylists(int N, int L, int K)
    {
        var mod = 1_000_000_007;
        
        var dp = new long[L+1, N+1];
        dp[0, 0] = 1;

        for (int i = 1; i <= L; i++)
        {
            for (int j = 1; j <= N; j++)
            {
                dp[i, j] += dp[i - 1, j - 1] * (N - j + 1);
                dp[i, j] += dp[i - 1, j] * Math.Max(j - K, 0);
                dp[i, j] %= mod;
            }
        }

        return (int) dp[L, N];
    }
}