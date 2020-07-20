using System;
using System.Collections.Generic;

namespace RotatedDigits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().RotatedDigits(10));
            Console.WriteLine(1 == new Solution().RotatedDigits(2));
            Console.WriteLine(247 == new Solution().RotatedDigits(857));
        }
    }
}

public class Solution
{
    public int RotatedDigits(int N)
    {
        var count = 0;

        for (var i = 1; i <= N; i++)
        {
            if (IsGoodNumber(i))
            {
                count++;
            }
        }
        
        return count;
    }

    private bool IsGoodNumber(int number)
    {
        var validFound = false;

        while (number > 0)
        {
            var digit = number % 10;
            if (digit == 2 || digit == 5 || digit == 6 || digit == 9)
            {
                validFound = true;
            }

            if (digit == 3 || digit == 4 || digit == 7)
            {
                return false;
            }

            number = number / 10;
        }
        
        return validFound;
    }
}