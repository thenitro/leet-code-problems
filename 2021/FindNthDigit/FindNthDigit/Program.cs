using System;

namespace FindNthDigit
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().FindNthDigit(3));
            Console.WriteLine(new Solution().FindNthDigit(11));
            Console.WriteLine(new Solution().FindNthDigit(1000000000));
        }
    }
}

public class Solution
{
    public int FindNthDigit(int n)
    {
        long length = 1;
        long digits = 9;
        long start = 1;

        while (n > length * digits)
        {
            n -= (int)(length * digits);
            digits *= 10;
            start *= 10;
            length++;
        }

        start += (n - 1) / length;

        var s = start.ToString();
        return s[(int)((n - 1) % length)] - '0';
    }
}