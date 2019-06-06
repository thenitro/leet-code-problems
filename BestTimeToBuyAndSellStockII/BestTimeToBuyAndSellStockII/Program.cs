using System;

namespace BestTimeToBuyAndSellStockII
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MaxProfit(new int[] {7, 1, 5, 3, 6, 4}));
            Console.WriteLine(new Solution().MaxProfit(new int[] {7, 6, 4, 3, 1}));
            Console.WriteLine(new Solution().MaxProfit(new int[] {1, 2, 3, 4, 5}));
        }
    }
}

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var result = 0;

        var min = int.MaxValue;
        var max = 0;

        for (var i = 0; i < prices.Length; i++)
        {
            var price = prices[i];

            if (price < min)
            {
                min = price;
            }
            else if (max < price - min)
            {
                max = price;
                result += max - min;

                i--;
                
                min = int.MaxValue;
                max = 0;
            }
        }

        return result;
    }
}