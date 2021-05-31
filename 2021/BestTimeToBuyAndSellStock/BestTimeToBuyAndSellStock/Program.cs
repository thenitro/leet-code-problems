using System;

namespace BestTimeToBuyAndSellStock
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().MaxProfit(new[] {7, 1, 5, 3, 6, 4}));
            Console.WriteLine(0 == new Solution().MaxProfit(new[] {7, 6, 4, 3, 1}));
        }
    }

    public class Solution
    {
        public int MaxProfit(int[] prices)
        {
            var min = int.MaxValue;
            var maxDiff = 0;

            for (var i = 0; i < prices.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                var diff = prices[i] - min;

                maxDiff = Math.Max(maxDiff, diff);
            }

            return maxDiff;
        }
    }
}