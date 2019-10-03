using System;

namespace FibonacciNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().Fib(2));
            Console.WriteLine(2 == new Solution().Fib(3));
            Console.WriteLine(3 == new Solution().Fib(4));
        }
    }
}

public class Solution
{
    public int Fib(int N)
    {
        if (N == 0 || N == 1)
        {
            return N;
        }
        
        var memo = new int[N + 1];
            memo[0] = 0;
            memo[1] = 1;

        for (var i = 2; i <= N; i++)
        {
            memo[i] = memo[i - 1] + memo[i - 2];
        }
        
        return memo[N];
    }
}