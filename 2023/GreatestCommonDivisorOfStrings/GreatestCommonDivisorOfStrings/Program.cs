using System;

namespace GreatestCommonDivisorOfStrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ABC" == new Solution().GcdOfStrings("ABCABC", "ABC"));
            Console.WriteLine("AB" == new Solution().GcdOfStrings("ABABAB", "ABAB"));
            Console.WriteLine("" == new Solution().GcdOfStrings("LEET", "CODE"));
            Console.WriteLine("ABAB" == new Solution().GcdOfStrings("ABABABAB", "ABAB"));
            Console.WriteLine("TAUXX" == new Solution().GcdOfStrings("TAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX"));
        }
    }
}