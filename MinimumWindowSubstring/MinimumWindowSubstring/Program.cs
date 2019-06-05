using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumWindowSubstring
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("BANC" == new Solution().MinWindow("ADOBECODEBANC", "ABC"));
            Console.WriteLine("A" == new Solution().MinWindow("A", "A"));
            Console.WriteLine("" == new Solution().MinWindow("A", "AA"));
            Console.WriteLine("" == new Solution().MinWindow("A", "B")); 
            Console.WriteLine("A" == new Solution().MinWindow("AA", "A"));
            Console.WriteLine("BAA" == new Solution().MinWindow("BBAA", "ABA"));
            Console.WriteLine("B" == new Solution().MinWindow("ABC", "B"));
        }
    }
}

public class Solution {
    public string MinWindow(string s, string t)
    {
        if (s.Length == 0 || t.Length == 0)
        {
            return string.Empty;
        }
        
        var dictT = new Dictionary<Char, int>();
        for (var i = 0; i < t.Length; i++)
        {
            var count = dictT.ContainsKey(t[i]) ? dictT[t[i]] : 0;
            dictT[t[i]] = count + 1;
        }

        var windowSize = dictT.Count;
        
        var l = 0;
        var r = 0;
        var formed = 0;
        
        var windowCounts = new Dictionary<Char, int>();
        var result = new int[] {-1, 0, 0};

        while (r < s.Length)
        {
            var c = s[r];
            var count = windowCounts.ContainsKey(c) ? windowCounts[c] : 0;
            windowCounts[c] = count + 1;

            if (dictT.ContainsKey(c) && windowCounts[c] == dictT[c])
            {
                formed++;
            }

            while (l <= r && formed == windowSize)
            {
                c = s[l];

                if (result[0] == -1 || r - l + 1 < result[0])
                {
                    result[0] = r - l + 1;
                    result[1] = l;
                    result[2] = r;
                }

                windowCounts[c] = windowCounts[c] - 1;

                if (dictT.ContainsKey(c) && windowCounts[c] < dictT[c])
                {
                    formed--;
                }

                l++;
            }

            r++;
        }

        return result[0] == -1 ? string.Empty : s.Substring(result[1], result[2] - result[1] + 1);
    }
}