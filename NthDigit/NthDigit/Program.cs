using System;

namespace NthDigit
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().FindNthDigit(3));
            Console.WriteLine(0 == new Solution().FindNthDigit(11));
            Console.WriteLine(4 == new Solution().FindNthDigit(323));
            Console.WriteLine(1 == new Solution().FindNthDigit(232));
            Console.WriteLine(1 == new Solution().FindNthDigit(1000000000));
            Console.WriteLine(2 == new Solution().FindNthDigit(2147483647));
        }
    }
}

public class Solution
{
    public int FindNthDigit(int n)
    {
        long digits = 9;
        long length = 1;
        long first = 1;

        while (n > length * digits)
        {
            n -= (int)(length * digits);
            length++;
            first *= 10;
            digits *= 10;
        }

        first += (n - 1) / length;

        var digitString = first.ToString();
        return digitString[(int)((n - 1) % length)] - '0';
    }
}