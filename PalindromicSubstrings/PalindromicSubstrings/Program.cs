using System;
using System.Text;

namespace PalindromicSubstrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().CountSubstrings("abc"));
            Console.WriteLine(6 == new Solution().CountSubstrings("aaa"));
        }
    }
}

public class Solution
{
    public int CountSubstrings(string s)
    {
        var result = 0;
        
        for (var i = 0; i < s.Length; i++)
        {
            for (var j = i + 1; j < s.Length + 1; j++)
            {
                if (IsPalindrome(s.Substring(i, j - i)))
                {
                    result++;
                }
            }
        }

        return result;
    }

    private bool IsPalindrome(string s)
    {
        for (var i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - i - 1])
            {
                return false;
            }
        }

        return true;
    }
}