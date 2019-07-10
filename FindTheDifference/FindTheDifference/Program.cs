using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace FindTheDifference
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine('e' == new Solution().FindTheDifference("abcd", "abcde"));
            Console.WriteLine('a' == new Solution().FindTheDifference("a", "aa"));
        }
    }
}

public class Solution {
    public char FindTheDifference(string s, string t)
    {
        var dict = new Dictionary<char, int>();

        var big = s.Length > t.Length ? s : t;
        var small = s.Length > t.Length ? t : s;

        foreach (var c in big)
        {
            dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
        }

        foreach (var c in small)
        {
            dict[c] = dict.ContainsKey(c) ? dict[c] - 1 : 0;
        }

        foreach (var kv in dict)
        {
            if (kv.Value > 0)
            {
                return kv.Key;
            }
        }
        
        return Char.MinValue;
    }
}