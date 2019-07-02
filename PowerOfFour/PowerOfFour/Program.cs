using System;

namespace PowerOfFour
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsPowerOfFour(16));
            Console.WriteLine(false == new Solution().IsPowerOfFour(5));
        }
    }
}

public class Solution {
    public bool IsPowerOfFour(int num) {
        while (true)
        {
            if (num == 1)
            {
                return true;
            }

            if (num == 0 || num % 4 != 0)
            {
                return false;
            }

            num /= 4;
        }
    }
}