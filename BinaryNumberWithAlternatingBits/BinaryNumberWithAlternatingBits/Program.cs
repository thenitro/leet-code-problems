using System;
using System.Runtime.Remoting;

namespace BinaryNumberWithAlternatingBits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().HasAlternatingBits(1));
            Console.WriteLine(true == new Solution().HasAlternatingBits(2));
            Console.WriteLine(false == new Solution().HasAlternatingBits(3));
            Console.WriteLine(false == new Solution().HasAlternatingBits(4));
            Console.WriteLine(true == new Solution().HasAlternatingBits(5));
            Console.WriteLine(false == new Solution().HasAlternatingBits(7));
            Console.WriteLine(false == new Solution().HasAlternatingBits(11));
            Console.WriteLine(true == new Solution().HasAlternatingBits(10));
        }
    }
}

public class Solution {
    public bool HasAlternatingBits(int n) {
        if (n == 0)
        {
            return false;
        }

        var str = Convert.ToString(n, 2);
        
        for (var i = 0; i < str.Length - 1; i++)
        {            
            if ((str[i] == '0' && str[i+1] != '1') ||
                (str[i] == '1' && str[i+1] != '0'))
            {
                return false;
            }
        }

        return true;
    }
}