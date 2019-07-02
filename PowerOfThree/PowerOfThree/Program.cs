using System;

namespace PowerOfThree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsPowerOfThree(27));
            Console.WriteLine(false == new Solution().IsPowerOfThree(0));
            Console.WriteLine(true == new Solution().IsPowerOfThree(9));
            Console.WriteLine(false == new Solution().IsPowerOfThree(45));
            Console.WriteLine(true == new Solution().IsPowerOfThree(1));
            Console.WriteLine(false == new Solution().IsPowerOfThree(2));
            Console.WriteLine(true == new Solution().IsPowerOfThree(3));
            Console.WriteLine(true == new Solution().IsPowerOfThree(81));
            Console.WriteLine(false == new Solution().IsPowerOfThree(90));
        }
    }
}

public class Solution {
    public bool IsPowerOfThree(int n)
    {
        while (true)
        {
            if (n == 1)
            {
                return true;
            }
        
            if (n == 0 || n % 3 != 0)
            {
                return false;
            }

            n = n / 3;
        }
    }
}