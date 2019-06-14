using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace IsomorphicString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsIsomorphic("egg", "add"));
            Console.WriteLine(new Solution().IsIsomorphic("foo", "bar"));
            Console.WriteLine(new Solution().IsIsomorphic("paper", "title"));
            Console.WriteLine(new Solution().IsIsomorphic("ab", "aa"));
        }
    }
}

public class Solution {
    public bool IsIsomorphic(string s, string t)
    {
        var dict = new Dictionary<char, char>();
        var dictT = new Dictionary<char, char>();

        for (int i = 0; i < s.Length; i++)
        {
            var sChar = s[i];
            var tChar = t[i];

            if (dict.ContainsKey(sChar))
            {
                if (!dictT.ContainsKey(tChar) || dictT[tChar] != sChar)
                {
                    return false;
                }
            } else if (dictT.ContainsKey(tChar))
            {
                if (!dict.ContainsKey(sChar) || dict[sChar] != tChar)
                {
                    return false;
                }
            }
            else
            {
                dict[sChar] = tChar;
                dictT[tChar] = sChar;
            }
        }

        return true;
    }
}