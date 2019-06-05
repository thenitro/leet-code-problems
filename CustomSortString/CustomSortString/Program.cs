using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace CustomSortString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().CustomSortString("cba", "abcd"));
        }
    }
}

public class Solution {
    public string CustomSortString(string S, string T)
    {
        var result = new List<string>();

        foreach (var currentChar in S)
        {
            var str = string.Empty;
            var count = T.Count(c => c == currentChar);
            
            for (var i = 0; i < count; i++)
            {
                str += currentChar;
            }
            
            result.Add(str);
        }

        foreach (var currentChar in T)
        {
            if (!S.Contains(currentChar))
            {
                result.Add(currentChar.ToString());
            }
        }

        return string.Join("", result);
    }
}