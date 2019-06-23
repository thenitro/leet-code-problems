using System;
using System.Collections.Generic;

namespace ValidAnagram
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsAnagram("anagram", "nagaram"));
            Console.WriteLine(false == new Solution().IsAnagram("rat", "car"));
            Console.WriteLine(false == new Solution().IsAnagram("ab", "a"));
        }
    }
}

public class Solution {
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }
        
        var dict = new Dictionary<char, int>();

        foreach (var c in s)
        {
            dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
        }

        foreach (var c in t)
        {
            if (!dict.ContainsKey(c) || dict[c] == 0)
            {
                return false;
            }

            dict[c] -= 1;
        }

        return true;
    }
}