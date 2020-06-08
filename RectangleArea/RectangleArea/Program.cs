using System;

namespace RectangleArea
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(45 == new Solution().ComputeArea(-3, 0, 3, 4, 0, -1, 9, 2));
        }
    }
}

public class Solution
{
    public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
    {
        var areaOfA = (C - A) * (D - B);
        var areaOfB = (G - E) * (H - F);

        var left = Math.Max(A, E);
        var right = Math.Min(C, G);
        var bottom = Math.Max(B, F);
        var top = Math.Min(D, H);

        var overlap = 0;
        
        if (right > left && top > bottom)
        {
            overlap = (right - left) * (top - bottom);
        }
        
        return areaOfA + areaOfB - overlap;
    }
}