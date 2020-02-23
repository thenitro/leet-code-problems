using System;

namespace MaximumLengthOfPairChain
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().FindLongestChain(new[] {new[] {1, 2}, new[] {2, 3}, new[] {3, 4}}));
            Console.WriteLine(2 == new Solution().FindLongestChain(new[] {new[] {3, 4}, new[] {2, 3}, new[] {1, 2}}));
            Console.WriteLine(4 == new Solution().FindLongestChain(new[] {new[]{-10,-8},new[] {8,9},new[]{-5,0},new[]{6,10},new[]{-6,-4},new[]{1,7},new[]{9,10},new[]{-4,7}}));
        }
    }
}

public class Solution
{
    public int FindLongestChain(int[][] pairs)
    {
        if (pairs == null || pairs.Length <= 1)
        {
            return 0;
        } 
        
        Array.Sort(pairs, (a, b) => a[0] - b[0]);
        
        var N = pairs.Length;
        var dp = new int[N];

        for (int i = 0; i < N; i++)
        {
            dp[i] = 1;
        }

        for (var j = 1; j < N; j++)
        {
            for (var i = 0; i < j; i++)
            {
                if (pairs[i][1] < pairs[j][0])
                {
                    dp[j] = Math.Max(dp[j], dp[i] + 1);
                }
            }
        }

        var ans = 0;

        for (int i = 0; i < N; i++)
        {
            if (dp[i] > ans)
            {
                ans = dp[i];
            }
        }
        
        return ans;
    }
}