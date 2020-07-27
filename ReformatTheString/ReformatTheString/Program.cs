using System;
using System.Collections.Generic;
using System.Text;

namespace ReformatTheString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().Reformat("a0b1c2"));
            Console.WriteLine(string.Empty == new Solution().Reformat("leetcode"));
            Console.WriteLine(string.Empty == new Solution().Reformat("1229857369"));
            Console.WriteLine(new Solution().Reformat("covid2019"));
            Console.WriteLine(new Solution().Reformat("ab123"));
        }
    }
}

public class Solution
{
    public string Reformat(string s)
    {
        var letters = new Stack<char>();
        var numbers = new Stack<char>();

        foreach (var c in s)
        {
            if (char.IsDigit(c))
            {
                numbers.Push(c);
            }
            else
            {
                letters.Push(c);
            }
        }

        if (Math.Abs(letters.Count - numbers.Count) > 1)
        {
            return string.Empty;
        }

        if (letters.Count > numbers.Count)
        {
            return Merge(letters, numbers);
        }

        return Merge(numbers, letters);
    }

    private string Merge(Stack<char> a, Stack<char> b)
    {
        var sb = new StringBuilder();
        var currentStack = a;

        while (currentStack.Count > 0)
        {
            sb.Append(currentStack.Pop());
            currentStack = currentStack == a ? b : a;
        }

        return sb.ToString();
    }
}