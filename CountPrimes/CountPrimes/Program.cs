using System;

namespace CountPrimes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().CountPrimes(10));
        }
    }
}

public class Solution {
    public int CountPrimes(int n)
    {
        var notPrime = new bool[n];

        var count = 0;
        for (var i = 2; i < n; i++)
        {
            if (notPrime[i] == false)
            {
                count++;

                for (var j = 2; i * j < n; j++)
                {
                    notPrime[i * j] = true;
                }
            }
        }

        return count;
    }
}