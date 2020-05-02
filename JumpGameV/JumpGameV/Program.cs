using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace JumpGameV
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().MaxJumps(new int[] {6, 4, 14, 6, 8, 13, 9, 7, 10, 6, 12}, 2));
            Console.WriteLine(7 == new Solution().MaxJumps(new int[] {7, 6, 5, 4, 3, 2, 1}, 1));
            Console.WriteLine(1 == new Solution().MaxJumps(new int[] {3, 3, 3, 3, 3}, 3));
            Console.WriteLine(2 == new Solution().MaxJumps(new int[] {7, 1, 7, 1, 7, 1}, 2));
            Console.WriteLine(1 == new Solution().MaxJumps(new int[] {66}, 1));
        }
    }
}

public class Solution
{
    public int MaxJumps(int[] arr, int d)
    {
        var dp = new int[arr.Length];
        var result = 1;
        
        for (var i = 0; i < arr.Length; i++)
        {
            result = Math.Max(result, MakeJumps(i, d, arr, dp));
        }
        
        return result;
    }

    private int MakeJumps(int index, int distance, int[] array, int[] dp)
    {
        if (dp[index] != 0)
        {
            return dp[index];
        }

        var result = 1;
        
        for (var j = index + 1; j <= Math.Min(index + distance, array.Length - 1) && array[j] < array[index]; j++)
        {
            result = Math.Max(result, 1 + MakeJumps(j, distance, array, dp));
        }

        for (var j = index - 1; j >= Math.Max(index - distance, 0) && array[j] < array[index]; j--)
        {
            result = Math.Max(result, 1 + MakeJumps(j, distance, array, dp));
        }

        dp[index] = result;
        
        return result;
    }
}