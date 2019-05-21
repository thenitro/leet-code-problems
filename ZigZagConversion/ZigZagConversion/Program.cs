using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ZigZagConversion
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("PAYPALISHIRING 3 {0}", "PAHNAPLSIIGYIR" == new Solution().Convert("PAYPALISHIRING", 3));
            Console.WriteLine("PAYPALISHIRING 4 {0}", "PINALSIGYAHRPI" == new Solution().Convert("PAYPALISHIRING", 4));
            Console.WriteLine("A 1 {0}", "A" == new Solution().Convert("A", 1));
            Console.WriteLine("AB 1 {0}", "AB" == new Solution().Convert("AB", 1));
            Console.WriteLine("ABC 1 {0}", "ABC" == new Solution().Convert("ABC", 1));
        }
    }
}

public class Solution {
    public string Convert(string s, int numRows)
    {
        if (string.IsNullOrEmpty(s) || numRows == 1)
        {
            return s;
        }
        
        var col = 0;
        var iterate = 1;
        
        var numbers = new string[numRows];
        
        for (var i = 0; i < s.Length; i++)
        {
            var currentRow = numbers[col] ?? string.Empty;            
                currentRow += s[i];
                
            numbers[col] = currentRow;
            
            col += iterate;

            if (col == numRows - 1)
            {
                iterate = -1;
            }

            if (col == 0)
            {
                iterate = 1;
            }
        }

        var result = string.Empty;
        
        for (var i = 0; i < numbers.Length; i++)
        {
            result += numbers[i];
        }

        return result;
    }
}