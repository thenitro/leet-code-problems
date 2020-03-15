using System;
using System.Collections.Generic;

namespace UniquePaths2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new SolutionRecursive().UniquePathsWithObstacles(
                                  new []
                                  {
                                      new []{ 0, 0, 0,},
                                      new []{ 0, 1, 0,},
                                      new []{ 0, 0, 0,},
                                  }));
            
            Console.WriteLine(0 == new SolutionRecursive().UniquePathsWithObstacles(
                                  new []
                                  {
                                      new []{ 1 },
                                  }));
            
            Console.WriteLine(2 == new Solution().UniquePathsWithObstacles(
                                  new []
                                  {
                                      new []{ 0, 0, 0,},
                                      new []{ 0, 1, 0,},
                                      new []{ 0, 0, 0,},
                                  }));
            
            Console.WriteLine(0 == new Solution().UniquePathsWithObstacles(
                                  new []
                                  {
                                      new []{ 1 },
                                  }));
        }
    }
}

public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        if (obstacleGrid[0][0] == 1)
        {
            return 0;
        }
        
        var lengthX = obstacleGrid.Length; 
        var lengthY = obstacleGrid[0].Length;

        obstacleGrid[0][0] = 1;

        for (var i = 1; i < lengthX; i++)
        {
            obstacleGrid[i][0] = obstacleGrid[i][0] == 0 && obstacleGrid[i - 1][0] == 1 ? 1 : 0;
        }
        
        for (var i = 1; i < lengthY; i++)
        {
            obstacleGrid[0][i] = obstacleGrid[0][i] == 0 && obstacleGrid[0][i - 1] == 1 ? 1 : 0;
        }

        for (var i = 1; i < lengthX; i++)
        {
            for (var j = 1; j < lengthY; j++)
            {
                if (obstacleGrid[i][j] == 0)
                {
                    obstacleGrid[i][j] = obstacleGrid[i - 1][j] + obstacleGrid[i][j - 1];
                }
                else
                {
                    obstacleGrid[i][j] = 0;
                }
            }
        }

        return obstacleGrid[lengthX - 1][lengthY - 1];
    }
}

public class SolutionRecursive
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var lengthX = obstacleGrid.GetLength(0); 
        var lengthY = obstacleGrid[0].Length;

        var visited = new Dictionary<int, Dictionary<int, int>>();
        
        return RecursiveHelper(0, 0, lengthX - 1, lengthY - 1, obstacleGrid, visited);
    }

    private int RecursiveHelper(int x, int y, int targetX, int targetY, int[][] obstacleGrid, Dictionary<int, Dictionary<int, int>> visited)
    {
        if (visited.ContainsKey(x) && visited[x].ContainsKey(y))
        {
            return visited[x][y];
        }
        
        if (x > targetX ||
            y > targetY)
        {
            return 0;
        }

        if (obstacleGrid[x][y] == 1)
        {
            return 0;
        }
        
        if (x == targetX && y == targetY)
        {
            return 1;
        }

        var result = RecursiveHelper(x + 1, y, targetX, targetY, obstacleGrid, visited) +
                     RecursiveHelper(x, y + 1, targetX, targetY, obstacleGrid, visited);

        if (visited.ContainsKey(x))
        {
            visited[x].Add(y, result);
        }
        else
        {
            var newDict = new Dictionary<int, int>();
                newDict.Add(y, result);
                
            visited[x] = newDict;
        } 

        return result;
    }
}