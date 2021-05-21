using System;

namespace Pow
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().MyPow(12, 0));
            Console.WriteLine(12 == new Solution().MyPow(12, 1));
            Console.WriteLine(12 * 12 == new Solution().MyPow(12, 2));
            Console.WriteLine(0.25 == new Solution().MyPow(2, -2));
        }
    }
    
    public class Solution {
        public double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n < 0)
            {
                if (n == int.MinValue)
                {
                    n /= 2;
                    x *= x;
                }

                n = -n;
                x = 1 / x;
            }

            if (n % 2 == 0)
            {
                return MyPow(x * x, n / 2);
            }

            return MyPow(x * x, n / 2) * x;
        }
    }
}