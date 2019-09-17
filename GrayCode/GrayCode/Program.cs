using System;
using System.Collections.Generic;

namespace GrayCode
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result1 = new Solution().GrayCode(2);
            Console.WriteLine(string.Join(",", result1));

            var result2 = new Solution().GrayCode(0);
            Console.WriteLine(string.Join(",", result2));
        }
    }
}

public class Solution
{
    public IList<int> GrayCode(int n)
    {
        var result = new List<int>();

        for (var i = 0; i < 1 << n; i++)
        {
            result.Add(i ^ i >> 1);
        }
        
        return result;
    }
}