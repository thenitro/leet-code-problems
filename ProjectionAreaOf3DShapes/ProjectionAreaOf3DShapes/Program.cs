using System;

namespace ProjectionAreaOf3DShapes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().ProjectionArea(new[] {new[] {2}}));
            Console.WriteLine(17 == new Solution().ProjectionArea(new[] {new[] {1, 2}, new[] {3, 4}}));
            Console.WriteLine(8 == new Solution().ProjectionArea(new[] {new[] {1, 0}, new[] {0, 2}}));
            Console.WriteLine(14 == new Solution().ProjectionArea(new[] {new[] {1, 1, 1}, new[] {1, 0, 1}, new[] {1, 1, 1}}));
            Console.WriteLine(21 == new Solution().ProjectionArea(new[] {new[] {2, 2, 2}, new[] {2, 1, 2}, new[] {2, 2, 2}}));
        }
    }
}

public class Solution
{
    public int ProjectionArea(int[][] grid)
    {
        var l = grid.Length;
        var z = 0;

        for (var i = 0; i < l; i++)
        {
            for (var j = 0; j < l; j++)
            {
                if (grid[i][j] != 0)
                {
                    z++;
                }
            }
        }

        var x = 0;
        for (var i = 0; i < l; i++)
        {
            var max = 0;
            for (var j = 0; j < l; j++)
            {
                if (grid[i][j] > max)
                {
                    max = grid[i][j];
                }
            }

            x += max;
        }

        var y = 0;
        for (var j = 0; j < l; j++)
        {
            var max = 0;
            for (var i = 0; i < l; i++)
            {
                if (grid[i][j] > max)
                {
                    max = grid[i][j];
                }
            }

            y += max;
        }

        return x + y + z;
    }
}