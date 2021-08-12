using System.Collections.Generic;

namespace MinimumAddToMakeParentheseValid
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

public class Solution
{
    public int MinAddToMakeValid(string s)
    {
        var stack = new Stack<char>();
        var closingParentheses = 0;

        foreach (var c in s)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
                else
                {
                    closingParentheses++;
                }
            }
        }

        return stack.Count + closingParentheses;
    }
}