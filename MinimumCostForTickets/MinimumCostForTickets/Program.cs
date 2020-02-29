using System;

namespace MinimumCostForTickets
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(11 == new Solution().MincostTickets(new[] {1, 4, 6, 7, 8, 20}, new[] {2, 7, 15}));
            Console.WriteLine(17 == new Solution().MincostTickets(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31},new[] {2, 7, 15}));
        }
    }
}

public class Solution
{
    public int MincostTickets(int[] days, int[] costs)
    {
        const int DAYS = 366;
        var travelDays = new bool[DAYS];

        for (var i = 0; i < days.Length; i++)
        {
            travelDays[days[i]] = true;
        }

        var dp = new int[DAYS];

        for (var i = 1; i < DAYS; i++)
        {
            dp[i] = int.MaxValue;
        }

        for (var i = 1; i < DAYS; i++)
        {
            if (!travelDays[i])
            {
                dp[i] = dp[i - 1];
                continue;
            }
            
            dp[i] = Math.Min(dp[i], dp[i - 1] + costs[0]);
            
            if (i - 7 >= 0)
            {
                dp[i] = Math.Min(dp[i], dp[i - 7] + costs[1]);
            }
            else
            {
                dp[i] = Math.Min(dp[i], costs[1]);
            }
            
            if (i - 30 >= 0)
            {
                dp[i] = Math.Min(dp[i], dp[i - 30] + costs[2]);
            }
            else
            {
                dp[i] = Math.Min(dp[i], costs[2]);
            }
        }
        
        return dp[DAYS - 1];
    }
}