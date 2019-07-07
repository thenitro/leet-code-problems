using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace BestTimeToBuyAndSellStockIV
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().MaxProfit(2, new[] {2, 4, 1}));
            Console.WriteLine(7 == new Solution().MaxProfit(2, new[] {3, 2, 6, 5, 0, 3}));
            Console.WriteLine(0 == new Solution().MaxProfit(2, new int[] {}));
            Console.WriteLine(0 == new Solution().MaxProfit(1, new[] { 2, 1}));
            Console.WriteLine(7 == new Solution().MaxProfit(2, new[] { 6, 1, 3, 2, 4, 7 }));
            Console.WriteLine(15 == new Solution().MaxProfit(4, new[] { 1,2,4,2,5,7,2,4,9,0}));
        }
    }
}

public class Solution
{
    public int MaxProfit(int k, int[] prices)
    {
        if (k == 0 || prices.Length == 0)
        {
            return 0;
        }

        if (k >= prices.Length)
        {
            return AllTimeProfit(prices);
        }

        var T = new int[prices.Length];
        var prev = new int[prices.Length];

        for (var i = 1; i <= k; i++)
        {
            var maxDiff = -prices[0];

            for (var j = 1; j < prices.Length; j++)
            {
                T[j] = Math.Max(T[j - 1], maxDiff + prices[j]);
                maxDiff = Math.Max(maxDiff, prev[j] - prices[j]);
            }

            for (var j = 1; j < prices.Length; j++)
            {
                prev[j] = T[j];
            }
        }
        
        return T[T.Length - 1];
    }

    private int AllTimeProfit(int[] arr)
    {
        var profit = 0;
        var localMin = arr[0];

        for (var i = 1; i < arr.Length; i++)
        {
            if (arr[i - 1] >= arr[i])
            {
                localMin = arr[i];
            }
            else
            {
                profit += arr[i] - localMin;
                localMin = arr[i];
            }
        }

        return profit;
    }
}