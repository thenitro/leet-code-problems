using System;

namespace ReverseVowelsOfString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("holle" == new Solution().ReverseVowels("hello"));
            Console.WriteLine("leotcede" == new Solution().ReverseVowels("leetcode"));
            Console.WriteLine("eo" == new Solution().ReverseVowels("oe"));
            Console.WriteLine("ll" == new Solution().ReverseVowels("ll"));
            Console.WriteLine("Aa" == new Solution().ReverseVowels("aA"));
        }
    }
}

public class Solution {
    public string ReverseVowels(string s)
    {
        var arr = s.ToCharArray();
        
        var lo = 0;
        var hi = s.Length - 1;

        while (lo < hi)
        {
            while (!IsVowel(s[lo]) && lo < hi)
            {
                lo++;
            }

            while (!IsVowel(s[hi]) && lo < hi)
            {
                hi--;
            }

            if (IsVowel(s[lo]) && IsVowel(s[hi]))
            {
                var temp = arr[lo];
                arr[lo] = arr[hi];
                arr[hi] = temp;
            }

            lo++;
            hi--;
        }
        
        return new string(arr);
    }

    private bool IsVowel(char c)
    {
        switch (Char.ToLower(c))
        {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return true;
        }

        return false;
    }
}