using System;

namespace RussianDollEnvelopes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().MaxEnvelopes(
                new[]
                {
                    new[] {5, 4},
                    new[] {6, 4},
                    new[] {6, 7},
                    new[] {2, 3},
                }));

            Console.WriteLine(3 == new Solution().MaxEnvelopes(
                new[]
                {
                    new[] { 30, 50 },
                    new[] { 12,2 },
                    new[] { 3,4 },
                    new[] { 12,15 }
                }));
            
            Console.WriteLine(5 == new Solution().MaxEnvelopes(
                new[]
                {
                    new[] { 2, 100 },
                    new[] { 3, 200 },
                    new[] { 4, 300 },
                    new[] { 5, 500 },
                    new[] { 5, 400 },
                    new[] { 5, 250 },
                    new[] { 6, 370 },
                    new[] { 6, 360 },
                    new[] { 7, 380 },
                }));
        }
    }
}

public class Solution
{
    public int MaxEnvelopes(int[][] envelopes)
    {
        Array.Sort(envelopes, (ints, ints1) => ints[0].CompareTo(ints1[0]));
        
        var maxCount = 1;
        var lis = new int[envelopes.Length];
        
        for (var i = 0; i < envelopes.Length; i++)
        {
            var count = 0;
            
            for (var j = 0; j < i; j++)
            {
                if (envelopes[i][0] > envelopes[j][0] &&
                    envelopes[i][1] > envelopes[j][1])
                {
                    if (lis[j] > count)
                    {
                        count = lis[j];
                    }
                }
            }

            lis[i] = count + 1;
            maxCount = Math.Max(maxCount, lis[i]);
        }
        
        return maxCount;
    }
}