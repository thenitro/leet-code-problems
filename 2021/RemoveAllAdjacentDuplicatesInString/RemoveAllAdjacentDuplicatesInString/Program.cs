using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveAllAdjacentDuplicatesInString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ca" == new Solution().RemoveDuplicates("abbaca"));
            Console.WriteLine("ay" == new Solution().RemoveDuplicates("azxxzy"));
        }
    }
}

public class Solution
{
    public string RemoveDuplicates(string s)
    {
        var stack = new Stack<char>();

        for (var i = 0; i < s.Length; i++)
        {
            if (stack.Count > 0 && stack.Peek() == s[i])
            {
                while (stack.Count > 0 && stack.Peek() == s[i])
                {
                    stack.Pop();
                }
            }
            else
            {
                stack.Push(s[i]);
            }
        }

        return new string(stack.Reverse().ToArray());
    }
}