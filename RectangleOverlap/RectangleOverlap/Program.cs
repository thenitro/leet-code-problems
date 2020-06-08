using System;

namespace RectangleOverlap
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsRectangleOverlap(new []{0, 0, 2, 2}, new [] {1, 1, 3, 3}));
            Console.WriteLine(false == new Solution().IsRectangleOverlap(new []{0, 0, 1, 1}, new [] {1, 0, 2, 1}));
            Console.WriteLine(false == new Solution().IsRectangleOverlap(new []{5, 15, 8, 18}, new [] {0, 3, 7, 9}));
        }
    }
}

public class Solution
{
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        var left = Math.Max(rec1[0], rec2[0]);
        var right = Math.Min(rec1[2], rec2[2]);
        var bottom = Math.Max(rec1[1], rec2[1]);
        var top = Math.Max(rec1[3], rec2[3]);

        Console.WriteLine((right - left) + " " + (top - bottom));
        Console.WriteLine((right - left) * (top - bottom));
        
        return right > left && top > bottom;
    }
}