using System;
using System.Runtime.Remoting.Metadata;

namespace OutOfBoundaryPaths
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().FindPaths(1, 1, 1, 0, 0));
            Console.WriteLine(6 == new Solution().FindPaths(2, 2, 2, 0, 0));
            Console.WriteLine(12 == new Solution().FindPaths(1, 3, 3, 0, 1));
        }
    }
}

public class Solution 
{
    public int FindPaths(int m, int n, int N, int i, int j)
    {
        var M = 1000000000 + 7;
        
        var dp = new int[m, n];
            dp[i, j] = 1;

        var count = 0;

        for (var moves = 1; moves <= N; moves++)
        {
            var temp = new int[m, n];
            
            for (var k = 0; k < m; k++)
            {
                for (var l = 0; l < n; l++)
                {
                    if (k == m - 1)
                    {
                        count = (count + dp[k, l]) % M;
                    }
                    
                    if (l == n - 1)
                    {
                        count = (count + dp[k, l]) % M;
                    }
                    
                    if (k == 0)
                    {
                        count = (count + dp[k, l]) % M;
                    }
                    
                    if (l == 0)
                    {
                        count = (count + dp[k, l]) % M;
                    }
                    
                    temp[k, l] = (
                        ((k > 0 ? dp[k - 1, l] : 0) + (k < m - 1 ? dp[k + 1, l] : 0)) % M + 
                        ((l > 0 ? dp[k, l - 1] : 0) + (l < n - 1 ? dp[k, l + 1] : 0)) % M) % M;
                }
            }

            dp = temp;
        }
        
        return count;
    }
}