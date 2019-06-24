using System;

namespace DivideTwoIntegers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().Divide(10, 3));
            Console.WriteLine(-2 == new Solution().Divide(7, -3));
            Console.WriteLine(2147483647 == new Solution().Divide(-2147483648, -1));
            Console.WriteLine(1 == new Solution().Divide(2, 2));
            Console.WriteLine(-2147483648 == new Solution().Divide(-2147483648, 1));
        }
    }
}

public class Solution {
    public int Divide(int dividend, int divisor)
    {
        var sign = (dividend < 0) ^ (divisor < 0) ? -1 : 1;
        var quotient = 0;

        if (dividend == int.MinValue)
        {
            if (divisor == -1)
            {
                return int.MaxValue;
            }

            if (divisor == int.MinValue)
            {
                return 1;
            }

            dividend += Math.Abs(divisor);
            quotient++;
        }

        if (divisor == int.MinValue)
        {
            return 0;
        }

        dividend = Math.Abs(dividend);
        divisor = Math.Abs(divisor);

        while (dividend >= divisor)
        {
            var tmp = divisor;
            var count = 1;

            while (dividend - tmp >= tmp)
            {
                tmp <<= 1;
                count <<= 1;
            }

            dividend -= tmp;
            quotient += count;
        }

        return sign * quotient;
    }
}