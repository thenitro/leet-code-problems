using System;
using System.Collections.Generic;

namespace ValidParentheses
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsValid("()"));
            Console.WriteLine(new Solution().IsValid("()[]{}"));
            Console.WriteLine(new Solution().IsValid("(]"));
            Console.WriteLine(new Solution().IsValid("([)]"));
            Console.WriteLine(new Solution().IsValid("{[]}"));
        }
    }
}

public class Solution {
    public bool IsValid(string s)
    {
        var list = new List<char>();

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            var isOpen = IsOpen(c); 
            if (isOpen)
            {
                list.Add(c);
            }
            else
            {
                if (list.Count > 0 && (list[list.Count - 1] == '(' && c == ')' || list[list.Count - 1] == '[' && c == ']' || list[list.Count - 1] == '{' && c == '}'))
                {
                    list.RemoveAt(list.Count - 1);
                }
                else
                {
                    list.Add(c);
                }
            }
        }
        
        return list.Count == 0;
    }
    
    private bool IsOpen(char c)
    {
        return c == '(' || c == '[' || c == '{';
    }

    private char GetChar(List<char> list, int i)
    {
        if (i > list.Count - 1)
        {
            return '!';
        }

        return list[i];
    }
}