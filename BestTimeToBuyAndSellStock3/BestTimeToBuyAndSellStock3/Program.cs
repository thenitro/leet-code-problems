using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BestTimeToBuyAndSellStock3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(6 == new Solution().MaxProfit(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 }));
            Console.WriteLine(4 == new Solution().MaxProfit(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(0 == new Solution().MaxProfit(new int[] { 7, 6, 4, 3, 1 }));
            Console.WriteLine(7 == new Solution().MaxProfit(new int[] { 3,2,6,5,0,3 }));
            Console.WriteLine(7 == new Solution().MaxProfit(new int[] { 6,1,3,2,4,7 }));
            Console.WriteLine(10 == new Solution().MaxProfit(new int[] { 1,3,5,4,3,7,6,9,2,4 }));
        }
    }
}

public class Solution {
    public int MaxProfit(int[] prices)
    {
        var oneBuy = int.MinValue;
        var twoBuy = int.MinValue;

        var oneBuyOneSell = 0;
        var twoBuyTwoSell = 0;

        foreach (var i in prices)
        {
            twoBuyTwoSell = Math.Max(twoBuyTwoSell, twoBuy + i);
            twoBuy = Math.Max(twoBuy, oneBuyOneSell - i);
            
            oneBuyOneSell = Math.Max(oneBuyOneSell, oneBuy + i); 
            oneBuy = Math.Max(oneBuy, -i);
        }

        return Math.Max(oneBuyOneSell, twoBuyTwoSell);
    }
}

    public class SolutionSlow {
    private class MaxPrice
    {
        public int Diff;
        public int StartIndex;
        public int EndIndex;

        public override string ToString()
        {
            return $"diff {Diff}, {StartIndex}:{EndIndex}";
        }
    }
    
    public int MaxProfit(int[] prices)
    {
        var results = new List<MaxPrice>();

        for (var i = 0; i < prices.Length - 1; i++)
        {
            for (var j = i + 1; j < prices.Length; j++)
            {
                results.Add(new MaxPrice() { Diff = prices[j] - prices[i], StartIndex = i, EndIndex = j });
            }
        }
        
        results.Sort((x,y) => y.Diff.CompareTo(x.Diff));
        
        var calculations = new List<int>();
        
        for (var j = 0; j < results.Count; j++)
        {
            var currentResult = results[j];
            var resultDiff = currentResult.Diff;
            var transactions = 1;

            if (resultDiff <= 0)
            {
                continue;
            }
            
            for (var i = 0; i < results.Count; i++)
            {
                if (i == j)
                {
                    continue;
                }
                
                if (results[i].StartIndex > currentResult.EndIndex && results[i].Diff >= 0)
                {
                    resultDiff += results[i].Diff;
                    currentResult = results[i];

                    transactions++;
                    
                    if (transactions == 2)
                    {
                        break;
                    }
                }    
            }
            
            calculations.Add(resultDiff);
        }

        var result = calculations.Count > 0 ? calculations.Max() : 0;
        
        return result;
    }
}