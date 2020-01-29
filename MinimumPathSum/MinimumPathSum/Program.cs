using System;

namespace MinimumPathSum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var grid = new[]
            {
                new[] { 1, 3, 1 },
                new[] { 1, 5, 1 },
                new[] { 4, 2, 1 },
            };

            Console.WriteLine(7 == new Solution().MinPathSum(grid));
        }
    }
}

public class Solution
{
    public int MinPathSum(int[][] grid) 
    {    
        var memo = new int[grid.Length, grid[0].Length];

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (i == 0 && j == 0)
                {
                    memo[i, j] = grid[i][j];
                    continue;
                }

                if (i == 0)
                {
                    memo[i, j] = memo[i, j - 1] + grid[i][j];
                    continue;
                }
                
                if (j == 0)
                {
                    memo[i, j] = memo[i - 1, j] + grid[i][j];
                    continue;
                }

                memo[i, j] = Math.Min(memo[i, j - 1], memo[i - 1, j]) + grid[i][j];
            }
        }

        /*for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                Console.Write(memo[i, j] + " ");
            }

            Console.WriteLine();
        }*/

        return memo[grid.Length - 1, grid[0].Length - 1];
    }
}