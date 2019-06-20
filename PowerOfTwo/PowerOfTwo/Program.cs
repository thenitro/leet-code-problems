using System;

namespace PowerOfTwo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsPowerOfTwo(1));
            Console.WriteLine(true == new Solution().IsPowerOfTwo(16));
            Console.WriteLine(false == new Solution().IsPowerOfTwo(218));
            Console.WriteLine(false == new Solution().IsPowerOfTwo(0));
        }
    }
}

public class Solution {
    public bool IsPowerOfTwo(int n)
    {
        if (n == 0) return false;
        
        while (true)
        {
            if (n == 1)
            {
                return true;
            }

            if (n % 2 != 0)
            {
                return false;
            }

            n = n >> 1;
        }
    }
}