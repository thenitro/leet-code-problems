using System;
using System.Collections.Generic;

namespace PermutationSequence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("213" == new Solution().GetPermutation(3, 3));
            Console.WriteLine("2314" == new Solution().GetPermutation(4, 9));
        }
    }
}

public class Solution
{
    public string GetPermutation(int n, int k)
    {
        var temp = new List<int>();
        var factorial = new int[n];
            factorial[0] = 1;

        for (var i = 1; i < n; i++)
        {
            factorial[i] = i * factorial[i-1];
        }

        for (var i = 1; i <= n; i++)
        {
            temp.Add(i);
        }

        k--;

        var result = string.Empty;
        for (var i = n - 1; i >= 0; i--)
        {
            var index = k / factorial[i];
            result += "" + temp[index];
            temp.RemoveAt(index);
            k = k % factorial[i];
        }

        return result;
    }
}