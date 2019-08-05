using System;
using System.Collections.Generic;

namespace LongestPalindrome
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(7 == new Solution().LongestPalindrome("abccccdd"));
            Console.WriteLine(6 == new Solution().LongestPalindrome("ccccdd"));
            Console.WriteLine(2 == new Solution().LongestPalindrome("dd"));
            Console.WriteLine(3 == new Solution().LongestPalindrome("cdd"));
            Console.WriteLine(1 == new Solution().LongestPalindrome("a"));
            Console.WriteLine(0 == new Solution().LongestPalindrome(""));
            Console.WriteLine(0 == new Solution().LongestPalindrome(null));
        }
    }
}

public class Solution {
    public int LongestPalindrome(string s) {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        var dict = new Dictionary<char, int>();
        foreach (var c in s)
        {
            dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
        }

        var hasNonEvent = false;
        var count = 0;

        foreach (var kv in dict)
        {
            if (kv.Value % 2 == 0)
            {
                count += kv.Value;
            }
            else {
                count += kv.Value - 1;
                hasNonEvent = true;
            }
        }

        return count + (hasNonEvent ? 1 : 0);
    }
}