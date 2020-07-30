using System;
using System.Collections.Generic;

namespace WildcardMatching
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(false == new Solution().IsMatch("aa", "a"));
            //Console.WriteLine(true == new Solution().IsMatch("aa", "??"));
            //Console.WriteLine(true == new Solution().IsMatch("aa", "*"));
            //Console.WriteLine(false == new Solution().IsMatch("cb", "?a"));
            Console.WriteLine(true == new Solution().IsMatch("adceb", "*a*b"));
            //Console.WriteLine(false == new Solution().IsMatch("acdcb", "a*c?b"));
        }
    }
}

public class Solution
{
    public bool IsMatch(string s, string p)
    {
        var indexS = 0;
        var indexP = 0;
        var match = 0;
        var starIdx = -1;

        while (indexS < s.Length)
        {
            if (indexP < p.Length && (p[indexP] == '?' || s[indexS] == p[indexP]))
            {
                indexP++;
                indexS++;
            }
            else if (indexP < p.Length && p[indexP] == '*')
            {
                starIdx = indexP;
                match = indexS;
                indexP++;
            }
            else if (starIdx != -1)
            {
                indexP = starIdx + 1;
                match++;
                indexS = match;
            }
            else
            {
                return false;
            }
        }
        
        while (indexP < p.Length && p[indexP] == '*')
        {
            indexP++;
        };
        
        return indexP == p.Length;
    }
}