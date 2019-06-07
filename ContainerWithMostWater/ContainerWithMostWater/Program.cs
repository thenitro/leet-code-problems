using System;

namespace ContainerWithMostWater
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(49 == new Solution2().MaxArea(new []{ 1, 8, 6, 2, 5, 4, 8, 3, 7}));
            Console.WriteLine(1 == new Solution2().MaxArea(new []{ 1, 8 }));
            Console.WriteLine(0 == new Solution2().MaxArea(new []{ 0, 2 }));
            Console.WriteLine(2 == new Solution2().MaxArea(new []{ 1, 2, 1 }));
        }
    }
}

public class Solution {
    public int MaxArea(int[] height)
    {
        var result = 0;

        for (var i = 0; i < height.Length; i++)
        {
            for (var j = i + 1; j < height.Length; j++)
            {
                var a = height[i];
                var b = height[j];

                var minHeight = Math.Min(a, b);
                var size = minHeight * (j - i);

                if (size > result)
                {
                    result = size;
                }
            }
        }

        return result;
    }
}

public class Solution2 {
    public int MaxArea(int[] height)
    {
        var result = 0;
        var l = 0;
        var r = height.Length - 1;
        
        while (l < r)
        {
            result = Math.Max(result, Math.Min(height[l], height[r]) * (r - l));

            if (height[l] < height[r])
            {
                l++;
            }
            else
            {
                r--;
            }
        }

        return result;
    }
}