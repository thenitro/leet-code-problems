using System;

namespace SumOfTwoIntegers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().GetSum(1, 2));
            Console.WriteLine(0 == new Solution().GetSum(-2, 2));
            Console.WriteLine(1 == new Solution().GetSum(-2, 3));
            Console.WriteLine(17 == new Solution().GetSum(0, 17));
        }
    }
}

public class Solution {
    public int GetSum(int a, int b)
    {
        if (a == 0) return b;
        if (b == 0) return a;

        while (b != 0)
        {
            var counter = a & b;
            
            a = a ^ b;
            b = counter << 1;
        }

        return a;
    }
}