using System;
using System.Linq;

namespace ReverseInteger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(321 == new Solution().Reverse(123));
            Console.WriteLine(-321 == new Solution().Reverse(-123));
            Console.WriteLine(21 == new Solution().Reverse(120));
            Console.WriteLine(0 == new Solution().Reverse(1534236469));
        }
    }
}

public class Solution
{
    public int Reverse(int x)
    {
        var result = 0;

        while (x != 0)
        {
            var remainder = x % 10;
            var temp = result * 10 + remainder;

            if ((temp - remainder) / 10 != result)
            {
                return 0;
            }

            result = temp;
            x /= 10;
        }

        return result;
    }
}