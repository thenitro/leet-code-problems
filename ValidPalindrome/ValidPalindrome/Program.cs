using System;
using System.Text.RegularExpressions;

namespace ValidPalindrome
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsPalindrome("A man, a plan, a canal: Panama"));
            Console.WriteLine(false == new Solution().IsPalindrome("race a car"));
            Console.WriteLine(false == new Solution().IsPalindrome("0P"));
            Console.WriteLine(false == new Solution().IsPalindrome("A"));
        }
    }
}

public class Solution {
    public bool IsPalindrome(string s)
    {
        var clean = Regex.Replace(s, "[^0-9a-zA-Z]", string.Empty);
        if (clean.Length < 2)
        {
            return true;
        }

        clean = clean.ToLower();

        var len = clean.Length;
        
        for (var i = 0; i < len; i++)
        {
            if (clean[i] != clean[len - i - 1])
            {
                return false;
            }
        }

        return true;
    }
}