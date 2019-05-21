using System;
using System.Linq;

namespace PalindromeNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("121 {0}", new Solution().IsPalindrome(121));
            Console.WriteLine("-121 {0}", new Solution().IsPalindrome(-121));
            Console.WriteLine("10 {0}", new Solution().IsPalindrome(10));
        }
    }
}

public class Solution
{
    public bool IsPalindrome(int x)
    {
        var strOriginal = x.ToString();
        var strReversed = string.Join("", strOriginal.Reverse());

        for (var i = 0; i < strOriginal.Length; i++)
        {
            if (strOriginal[i] != strReversed[i])
            {
                return false;
            }
        }

        return true;
    }
}