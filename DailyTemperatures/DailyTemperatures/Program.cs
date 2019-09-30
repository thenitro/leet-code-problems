using System;
using System.Collections.Generic;

namespace DailyTemperatures
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().DailyTemperatures(new[] {73, 74, 75, 71, 69, 72, 76, 73});
            Console.WriteLine(string.Join(",", result));//1, 1, 4, 2, 1, 1, 0, 0
        }
    }
}

public class Solution
{
    public int[] DailyTemperatures(int[] T)
    {
        var result = new int[T.Length];
        var stack = new Stack<int>();

        for (var i = T.Length - 1; i >= 0; i--)
        {
            while (stack.Count != 0 && T[i] >= T[stack.Peek()])
            {
                stack.Pop();
            }

            result[i] = stack.Count == 0 ? 0 : stack.Peek() - i;
            stack.Push(i);
        }

        return result;
    }
}