using System;

namespace Sqrt
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().MySqrt(4));
            Console.WriteLine(2 == new Solution().MySqrt(8));
            Console.WriteLine(1 == new Solution().MySqrt(1));
            Console.WriteLine(1 == new Solution().MySqrt(2));
            Console.WriteLine(46340 == new Solution().MySqrt(2147395600));
            Console.WriteLine(46340 == new Solution().MySqrt(2147483647));
        }
    }
}

public class Solution {
    public int MySqrt(int x) {
        if (x == 1)
        {
            return 1;
        }

        var l = 1;
        var r = x / 2 + 1;

        while (l < r)
        {
            var m = (r + l) / 2;

            if (x / m < m)
            {
                r = m;
            }
            else
            {
                l = m + 1;
            }
        }

        return --l;
    }
}