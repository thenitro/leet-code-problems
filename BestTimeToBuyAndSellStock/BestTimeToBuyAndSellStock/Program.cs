using System;

namespace BestTimeToBuyAndSellStock
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
        }
    }
}

public class Solution {
    public int MaxProfit(int[] prices)
    {
        var currentMax = 0;

        for (var i = 0; i < prices.Length - 1; i++)
        {
            for (var j = i + 1; j < prices.Length; j++)
            {
                var diff = prices[j] - prices[i];

                if (diff > currentMax)
                {
                    currentMax = diff;
                }
            }
        }

        return currentMax;
    }
}