using System;

namespace LargestRectangleInHistogram
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(10 == new Solution().LargestRectangleArea(new[] {2, 1, 5, 6, 2, 3}));
            Console.WriteLine(0 == new Solution().LargestRectangleArea(new int[0]));
        }
    }
}

public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        if (heights.Length == 0)
        {
            return 0;
        }
        
        var max = int.MinValue;
        
        for (var i = 0; i < heights.Length; i++)
        {
            var minElement = int.MaxValue;
            
            for (var j = i; j < heights.Length; j++)
            {                
                minElement = Math.Min(minElement, heights[j]);
                max = Math.Max(minElement * (j + 1 - i), max);
            }
        }

        return max;
    }
}