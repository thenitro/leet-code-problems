using System.Collections.Generic;

namespace BuildingsWithOceanView
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
    public int[] FindBuildings(int[] heights)
    {
        var stack = new Stack<int>();

        for (var i = 0; i < heights.Length; i++)
        {
            var currentHeight = heights[i];

            while (stack.Count > 0 && heights[stack.Peek()] <= currentHeight)
            {
                stack.Pop();
            }
            
            stack.Push(i);
        }

        var result = new int[stack.Count];

        while (stack.Count > 0)
        {
            result[stack.Count - 1] = stack.Pop();
        }

        return result;
    }
}