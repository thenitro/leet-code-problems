using System;

namespace LongestUncommonSubsequence1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().FindLUSlength("aba", "cdc"));
            Console.WriteLine(3 == new Solution().FindLUSlength("a", "adc"));
            Console.WriteLine(7 == new Solution().FindLUSlength("aba", "cabaedc"));
            Console.WriteLine(7 == new Solution().FindLUSlength("eaba", "cabaedc"));
        }
    }
}

public class Solution
{
    public int FindLUSlength(string a, string b)
    {
        if (a.Equals(b))
        {
            return -1;
        }

        return Math.Max(a.Length, b.Length);
    }
}