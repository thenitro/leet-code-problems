using System;

namespace PalindromeNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsPalindrome(121));
            Console.WriteLine(false == new Solution().IsPalindrome(-121));
            Console.WriteLine(true == new Solution().IsPalindrome(11));
            Console.WriteLine(false == new Solution().IsPalindrome(10));
        }
    }
}