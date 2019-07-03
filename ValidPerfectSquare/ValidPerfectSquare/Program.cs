using System;

namespace ValidPerfectSquare
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsPerfectSquare(9));
            Console.WriteLine(true == new Solution().IsPerfectSquare(16));
            Console.WriteLine(false == new Solution().IsPerfectSquare(14));
            Console.WriteLine(true == new Solution().IsPerfectSquare(1));
            Console.WriteLine(false == new Solution().IsPerfectSquare(2147483647));
            Console.WriteLine(true == new Solution().IsPerfectSquare(100));
        }
    }
}

public class Solution {
    public bool IsPerfectSquare(int num)
    {
        long x = num;

        while (x * x > num)
        {
            x = (x + num / x) >> 1;
        }

        return x * x == num;
    }
}