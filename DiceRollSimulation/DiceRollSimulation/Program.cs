using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace DiceRollSimulation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(34 == new Solution().DieSimulator(2, new[] {1, 1, 2, 2, 2, 3}));
            Console.WriteLine(30 == new Solution().DieSimulator(2, new[] {1, 1, 1, 1, 1, 1}));
            Console.WriteLine(181 == new Solution().DieSimulator(3, new[] {1, 1, 1, 2, 2, 3}));
        }
    }
}


public class Solution
{
    private int _combinations;
    
    public int DieSimulator(int n, int[] rollMax)
    {
        var divisor = (long)Math.Pow(10, 9) + 7;
        var dp = new long[n, 7];

        for (var j = 0; j < 6; j++)
        {
            dp[0, j] = 1;
        }

        dp[0, 6] = 6;

        for (var i = 1; i < n; i++)
        {
            var sum = (long)0;
            
            for (var j = 0; j < 6; j++)
            {
                dp[i, j] = dp[i - 1, 6];

                if (i - rollMax[j] < 0)
                {
                    sum = (sum + dp[i, j]) % divisor;
                }
                else
                {
                    if (i - rollMax[j] - 1 >= 0)
                    {
                        dp[i, j] = (dp[i, j] - (dp[i - rollMax[j] - 1, 6] - dp[i - rollMax[j] - 1, j])) % divisor + divisor;
                    }
                    else
                    {
                        dp[i, j] = (dp[i, j] - 1) % divisor;
                    }

                    sum = (sum + dp[i, j]) % divisor;
                }
            }

            dp[i, 6] = sum;
        }

        return (int)dp[n - 1, 6];
    }
}