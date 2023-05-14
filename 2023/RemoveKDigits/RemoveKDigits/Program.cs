using System;

namespace RemoveKDigits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1219" == new Solution().RemoveKdigits("1432219", 3));
            Console.WriteLine("0" == new Solution().RemoveKdigits("10", 2));
            Console.WriteLine("0" == new Solution().RemoveKdigits("9", 1));
        }
    }
}