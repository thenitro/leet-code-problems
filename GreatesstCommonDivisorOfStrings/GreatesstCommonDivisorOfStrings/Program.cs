using System;

namespace GreatesstCommonDivisorOfStrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ABC" == new Solution().GcdOfStrings("ABCABC", "ABC"));
            Console.WriteLine("AB" == new Solution().GcdOfStrings("ABABAB", "ABAB"));
            Console.WriteLine("" == new Solution().GcdOfStrings("LEET", "CODE"));
        }
    }
}

public class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1)
        {
            return string.Empty;
        }

        var len = str1.Length;
        var len2 = str2.Length;

        var gcd = Gcd(len, len2);
        if (len < len2)
        {
            return str1.Substring(0, gcd);
        }

        return str2.Substring(0, gcd);
    }

    public int Gcd(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }

        return a % b == 0 ? b : Gcd(b, a % b);
    }
}