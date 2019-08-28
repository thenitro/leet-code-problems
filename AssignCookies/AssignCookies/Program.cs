using System;
using System.Collections.Generic;

namespace AssignCookies
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().FindContentChildren(new[] {1, 2, 3}, new[] {1, 1}));
            Console.WriteLine(2 == new Solution().FindContentChildren(new[] {1, 2}, new[] {1, 2, 3}));
            Console.WriteLine(1 == new Solution().FindContentChildren(new[] {1, 2, 3}, new[] {3}));
        }
    }
}

public class Solution
{
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);

        var i = 0;

        for (int j = 0; i < g.Length && j < s.Length; j++)
        {
            if (g[i] <= s[j])
            {
                i++;
            }
        }

        return i;
    }
}