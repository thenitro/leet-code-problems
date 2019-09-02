using System;

namespace BestTimeToBuyAndSellStockWithTransactionFee
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(8 == new Solution().MaxProfit(new[] {1, 3, 2, 8, 4, 9}, 2));
        }
    }
}

public class Solution
{
    public int MaxProfit(int[] prices, int fee)
    {
        var sell = 0;
        var buy = -prices[0];
        var maxSell = 0;

        for (var i = 1; i < prices.Length; i++)
        {
            sell = Math.Max(sell, buy + prices[i] - fee);
            buy = Math.Max(buy, sell - prices[i]);
            maxSell = Math.Max(sell, maxSell);
        }

        return maxSell;
    }
}