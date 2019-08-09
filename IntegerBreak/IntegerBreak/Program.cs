using System;

namespace IntegerBreak
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().IntegerBreak(2));
            Console.WriteLine(36 == new Solution().IntegerBreak(10));
        }
    }
}

public class Solution {
    public int IntegerBreak(int n) {
        if (n == 2)
        {
            return 1;
        }

        if (n == 3)
        {
            return 2;
        }

        var product = 1;

        while (n > 4)
        {
            product *= 3;
            n -= 3;
        }

        product *= n;

        return product;
    }
}