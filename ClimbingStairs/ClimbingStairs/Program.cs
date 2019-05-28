using System;

namespace ClimbingStairs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().ClimbStairs(2));
            Console.WriteLine(3 == new Solution().ClimbStairs(3));
        }
    }
}

public class Solution {
    public int ClimbStairs(int n) {
        if (n == 1)
        {
            return 1;
        }

        var first = 1;
        var second = 2;

        for (var i = 3; i <= n; i++)
        {
            var third = first + second;
            first = second;
            second = third;
        }

        return second;
    }
}