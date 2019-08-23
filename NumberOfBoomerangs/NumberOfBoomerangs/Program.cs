using System;
using System.Collections.Generic;

namespace NumberOfBoomerangs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().NumberOfBoomerangs(new[] {new[] {0, 0,}, new[] {1, 0,}, new[] {2, 0,}}));
        }
    }
}

public class Solution
{
    public int NumberOfBoomerangs(int[][] points)
    {
        var result = 0;

        for (int i = 0; i < points.Length; i++)
        {
            var dict = new Dictionary<long, int>();

            for (var j = 0; j < points.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                var dy = points[i][1] - points[j][1];
                var dx = points[i][0] - points[j][0];

                var key = dy * dy + dx * dx;

                dict[key] = dict.ContainsKey(key) ? dict[key] + 1 : 1;
            }

            foreach (var value in dict.Values)
            {
                if (value > 1)
                {
                    result += value * (value - 1);
                }
            }
        }
        
        return result;
    }
}