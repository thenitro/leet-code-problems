using System;
using System.Collections.Generic;

namespace PascalsTriangleII
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().GetRow(3);
            
            PrintResult(result);
            Console.WriteLine("----");
            
            result = new Solution().GetRow(4);
            
            PrintResult(result);
            Console.WriteLine("----");
            
            result = new Solution().GetRow(5);
            
            PrintResult(result);
            Console.WriteLine("----");
            
            result = new Solution().GetRow(6);
            
            PrintResult(result);
            Console.WriteLine("----");
        }

        private static void PrintResult(IList<int> r)
        {
            foreach (var i in r)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
        }
    }
}

public class Solution
{
    public IList<int> GetRow(int rowIndex)
    {
        var result = new int[rowIndex + 1];
            result[0] = 1;

        for (var i = 1; i < rowIndex + 1; i++)
        {
            for (var j = i; j >= 1; j--)
            {
                result[j] += result[j - 1];
            }
        }

        return result;
    }
}