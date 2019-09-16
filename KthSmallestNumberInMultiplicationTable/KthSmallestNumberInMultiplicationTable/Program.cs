using System;
using System.Collections.Generic;

namespace KthSmallestNumberInMultiplicationTable
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().FindKthNumber(3, 3, 5));
            Console.WriteLine(6 == new Solution().FindKthNumber(2, 3, 6));
        }
    }
}

public class Solution
{
    public int FindKthNumber(int m, int n, int k)
    {
        var lo = 1;
        var hi = m * n;

        while (lo < hi)
        {
            var mi = lo + (hi - lo) / 2;
            if (!Enough(mi, m, n, k))
            {
                lo = mi + 1;
            }
            else
            {
                hi = mi;
            }
        }

        return lo;
    }

    private bool Enough(int x, int m, int n, int k)
    {
        var count = 0;

        for (int i = 1; i <= m; i++)
        {
            count += Math.Min(x / i, n);
        }

        return count >= k;
    }
}

public class SolutionOutOfMemory
{
    public int FindKthNumber(int m, int n, int k)
    {
        var matrix = new int[m, n];
        var elements = new List<int>();

        for (var i = 0; i < m; i++)
        {
            matrix[i, 0] = i + 1;
            elements.Add(matrix[i,0]);
        }
        
        for (var j = 0; j < n; j++)
        {
            matrix[0, j] = j + 1;
            elements.Add(matrix[0,j]);
        }

        for (var i = 1; i < m; i++)
        {
            for (var j = 1; j < n; j++)
            {
                matrix[i, j] = matrix[i, 0] * matrix[0, j];
                elements.Add(matrix[i,j]);
            }
        }
        
        elements.Sort();
        
        return elements[k];
    }
}