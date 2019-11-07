using System;

namespace NumTrees
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().NumTrees(3));
        }
    }
}

public class Solution
{
    public int NumTrees(int n)
    {
        var G = new int[n + 1];
            G[0] = 1;
            G[1] = 1;

        for (var i = 2; i <= n; i++)
        {
            for (var j = 1; j <= i; j++)
            {
                G[i] += G[j - 1] * G[i - j];
            }
        }

        return G[n];
    }
}