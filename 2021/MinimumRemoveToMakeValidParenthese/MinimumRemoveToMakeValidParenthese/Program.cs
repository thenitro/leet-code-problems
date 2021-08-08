using System;
using System.Collections.Generic;
using System.Text;

namespace MinimumRemoveToMakeValidParenthese
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("lee(t(c)o)de" == new Solution().MinRemoveToMakeValid("lee(t(c)o)de)"));
        }
    }
}

public class Solution
{
    public string MinRemoveToMakeValid(string s)
    {
        var indexesToRemove = new HashSet<int>();
        var stack = new Stack<int>();

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                stack.Push(i);
            }

            if (s[i] == ')')
            {
                if (stack.Count == 0)
                {
                    indexesToRemove.Add(i);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        while (stack.Count > 0)
        {
            indexesToRemove.Add(stack.Pop());
        }

        var sb = new StringBuilder();

        for (var i = 0; i < s.Length; i++)
        {
            if (!indexesToRemove.Contains(i))
            {
                sb.Append(s[i]);
            }
        }

        return sb.ToString();
    }
}