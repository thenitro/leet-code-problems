using System;
using System.Collections.Generic;
using System.Data;

namespace ExcelSheetColumnNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().TitleToNumber("A"));
            Console.WriteLine(28 == new Solution().TitleToNumber("AB"));
            Console.WriteLine(701 == new Solution().TitleToNumber("ZY"));
        }
    }
}

public class Solution
{
    private Dictionary<char, int> Map = new Dictionary<char, int>()
    {
        {'A', 1},
        {'B', 2},
        {'C', 3},
        {'D', 4},
        {'E', 5},
        {'F', 6},
        {'G', 7},
        {'H', 8},
        {'I', 9},
        {'J', 10},
        {'K', 11},
        {'L', 12},
        {'M', 13},
        {'N', 14},
        {'O', 15},
        {'P', 16},
        {'Q', 17},
        {'R', 18},
        {'S', 19},
        {'T', 20},
        {'U', 21},
        {'V', 22},
        {'W', 23},
        {'X', 24},
        {'Y', 25},
        {'Z', 26},
    };
    
    public int TitleToNumber(string s)
    {
        var result = 0;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var c = s[i];
            var x = (int)(Map[c] * Math.Pow(26, s.Length - i - 1));

            result += x;
        }
        
        return result;
    }
}