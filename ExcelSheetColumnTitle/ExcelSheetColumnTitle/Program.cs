using System;
using System.Collections.Generic;

namespace ExcelSheetColumnTitle
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("A" == new Solution().ConvertToTitle(1));
            Console.WriteLine("Z" == new Solution().ConvertToTitle(26));
            Console.WriteLine("AB" == new Solution().ConvertToTitle(28));
            Console.WriteLine("ZY" == new Solution().ConvertToTitle(701));
            Console.WriteLine("ZZ" == new Solution().ConvertToTitle(702));
        }
    }
}

public class Solution
{
    public string ConvertToTitle(int n)
    {
        var stack = new Stack<char>();
        
        while (n > 0)
        {
            n--;
            stack.Push((char)('A' + n % 26));
            n /= 26;
        }
        
        return new string(stack.ToArray());
    }
}