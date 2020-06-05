using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperPalindromes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().SuperpalindromesInRange("4", "1000"));
            Console.WriteLine(6 == new Solution().SuperpalindromesInRange("398904669", "13479046850"));
        }
    }
}

public class Solution
{
    public int SuperpalindromesInRange(string L, string R)
    {
        var l = long.Parse(L);
        var r = long.Parse(R);

        var result = 0;

        for (var i = (long)Math.Sqrt(l); i * i <= r;)
        {
            var p = Next(i);

            if (p * p <= r && IsPalindrome(p * p))
            {
                result++;
            }

            i = p + 1;
        }

        return result;
    }
    
    private long Next(long l)
    {
        var s = l.ToString();
        var len = s.Length;
        
        var cands = new List<long>();
            cands.Add((long)Math.Pow(10, len) - 1);

        var half = s.Substring(0, (len + 1) / 2);
        var nextHalf = (long.Parse(half) + 1).ToString();
        var reverse = new string(half.Substring(0, len / 2).Reverse().ToArray());
        var nextReverse = new string(nextHalf.Substring(0, len / 2).Reverse().ToArray());
        
        cands.Add(long.Parse(half + reverse));
        cands.Add(long.Parse(nextHalf + nextReverse));

        var result = long.MaxValue;

        foreach (var i in cands)
        {
            if (i >= l)
            {
                result = Math.Min(result, i);
            }
        }

        return result;
    }

    public bool IsPalindrome(long n)
    {
        long divisor = 1;

        while (n / divisor >= 10)
        {
            divisor *= 10;
        }

        while (n != 0)
        {
            var leading = n / divisor;
            var trailing = n % 10;

            if (leading != trailing)
            {
                return false;
            }

            n = (n % divisor) / 10;
            divisor /= 100;
        }

        return true;
    }
}