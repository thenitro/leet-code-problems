using System;

namespace IslandPerimeter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(16 == new Solution().IslandPerimeter(new []
            {
                new []{ 0, 1, 0, 0 },
                new []{ 1, 1, 1, 0 },
                new []{ 0, 1, 0, 0 },
                new []{ 1, 1, 0, 0 },
            }));
        }
    }
}

public class Solution {
    public int IslandPerimeter(int[][] grid)
    {
        var count = 0;
        
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                count += AmountOfPerimeterPerCell(i, j, grid);
            }
        }

        Console.WriteLine(count);

        return count;
    }

    private int AmountOfPerimeterPerCell(int i, int j, int[][] grid)
    {
        if (grid[i][j] == 0)
        {
            return 0;
        }
        
        return IsPerimeter(i + 1, j, grid) +
               IsPerimeter(i - 1, j, grid) +
               IsPerimeter(i, j + 1, grid) +
               IsPerimeter(i, j - 1, grid);
    }

    private int IsPerimeter(int i, int j, int[][] grid)
    {
        if (i < 0 || j < 0 || 
            i >= grid.Length || j >= grid[i].Length || 
            grid[i][j] == 0)
        {
            return 1;
        }

        return 0;
    } 
}