using System;

namespace FactorialTrailingZeroes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(0 == new Solution().TrailingZeroes(3));
            Console.WriteLine(1 == new Solution().TrailingZeroes(5));
            Console.WriteLine(0 == new Solution().TrailingZeroes(0));
            Console.WriteLine(1 == new Solution().TrailingZeroes(6));
            Console.WriteLine(2 == new Solution().TrailingZeroes(13));
            Console.WriteLine(7 == new Solution().TrailingZeroes(30));
        }
    }
}

public class Solution {
    public int TrailingZeroes(int n)
    {
        var count = 0;

        while (n != 0)
        {
            var tmp = n / 5;
            count += tmp;
            n = tmp;
        }

        return count;
    }
}