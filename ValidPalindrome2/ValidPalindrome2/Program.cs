using System;
using System.Collections.Generic;

namespace ValidPalindrome2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().ValidPalindrome("aba"));
            Console.WriteLine(true == new Solution().ValidPalindrome("abca"));
            Console.WriteLine(true == new Solution().ValidPalindrome("acbca"));
            Console.WriteLine(true == new Solution().ValidPalindrome("abbda"));
            Console.WriteLine(false == new Solution().ValidPalindrome("acbda"));
            Console.WriteLine(false == new Solution().ValidPalindrome("abc"));
            Console.WriteLine(true == new Solution().ValidPalindrome("aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga"));
            Console.WriteLine(true == new Solution().ValidPalindrome("aguokepatgbnvfqmgmlucupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuclmgmqfvnbgtapekouga"));
        }
    }
}

public class Solution {
    public bool ValidPalindrome(string s)
    {
        var middle = s.Length / 2;

        for (var i = 0; i < middle; i++)
        {
            var j = s.Length - 1 - i;
            
            if (s[i] != s[j])
            {
                return IsPalindromeRange(s, i + 1, j) || IsPalindromeRange(s, i, j - 1);
            }
        }

        return true;
    }

    private bool IsPalindromeRange(string s, int startIndex, int endIndex)
    {
        for (var i = startIndex; i <= startIndex + (endIndex - startIndex) / 2; i++)
        {
            if (s[i] != s[endIndex - i + startIndex])
            {
                return false;
            }
        }

        return true;
    }
}