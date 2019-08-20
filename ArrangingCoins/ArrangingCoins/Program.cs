using System;

namespace ArrangingCoins
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(0 == new Solution().ArrangeCoins(0));
            Console.WriteLine(1 == new Solution().ArrangeCoins(1));
            Console.WriteLine(2 == new Solution().ArrangeCoins(3));
            Console.WriteLine(2 == new Solution().ArrangeCoins(5));
            Console.WriteLine(3 == new Solution().ArrangeCoins(6));
            Console.WriteLine(3 == new Solution().ArrangeCoins(8));
            Console.WriteLine(4 == new Solution().ArrangeCoins(10));
        }
    }
}

public class Solution {
    public int ArrangeCoins(int n)
    {
        var result = 0;
        var count = 1;

        while (n - count >= 0)
        {
            n -= count;
            count++;
            result++;
        }
        
        return result;
    }
}