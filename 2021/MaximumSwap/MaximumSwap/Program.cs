using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumSwap
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(7236 == new Solution().MaximumSwap(2736));
            Console.WriteLine(9973 == new Solution().MaximumSwap(9973));
            Console.WriteLine(71 == new Solution().MaximumSwap(17));
            Console.WriteLine(1 == new Solution().MaximumSwap(1));
        }
    }
}

public class Solution
{
    public int MaximumSwap(int num)
    {
        var digits = num.ToString().ToCharArray();
        var max = -1;
        var maxIndex = -1;
        var leftIndex = 0;
        var rightIndex = 0;

        for (var i = digits.Length - 1; i >= 0; i--)
        {
            var digit = digits[i] - '0';
            if (digit > max)
            {
                max = digit;
                maxIndex = i;
            }

            if (digit < max)
            {
                leftIndex = i;
                rightIndex = maxIndex;
            }
        }

        var tmp = digits[leftIndex];
        digits[leftIndex] = digits[rightIndex];
        digits[rightIndex] = tmp;

        return int.Parse(new string(digits));
    }
}