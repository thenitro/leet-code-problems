using System;
using System.Collections.Generic;

namespace NumberOfIslands
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().NumIslands(new char[][]
            {
                new char[] {'1', '1', '1', '1', '0'},
                new char[] {'1', '1', '0', '1', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'0', '0', '0', '0', '0'},
            }));

            Console.WriteLine(3 == new Solution().NumIslands(new char[][]
            {
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'0', '0', '1', '0', '0'},
                new char[] {'0', '0', '0', '1', '1'},
            }));
        }
    }
}

public class Solution
{
    public int NumIslands(char[][] grid)
    {
        var result = 0;
        var visited = new Dictionary<int, Dictionary<int, bool>>();

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (visited.ContainsKey(i) && visited[i].ContainsKey(j))
                {
                    continue;
                }

                if (grid[i][j] == '0')
                {
                    continue;
                }

                BFS(visited, i, j, grid);
                result++;
            }
        }

        return result;
    }

    private void BFS(Dictionary<int, Dictionary<int, bool>> visited, int i, int j, char[][] grid)
    {
        var queue = new Queue<int[]>();
            queue.Enqueue(new int[] {i, j});

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node == null)
            {
                continue;
            }

            i = node[0];
            j = node[1];

            if (i < 0 || i > grid.Length - 1)
            {
                continue;
            }

            if (j < 0 || j > grid[i].Length - 1)
            {
                continue;
            }

            if (visited.ContainsKey(i) && visited[i].ContainsKey(j))
            {
                continue;
            }

            MarkAsVisited(visited, i, j);

            if (grid[i][j] == '0')
            {
                continue;
            }

            queue.Enqueue(new int[] {i - 1, j});
            queue.Enqueue(new int[] {i + 1, j});
            queue.Enqueue(new int[] {i, j - 1});
            queue.Enqueue(new int[] {i, j + 1});
        }
    }

    private void MarkAsVisited(Dictionary<int, Dictionary<int, bool>> visited, int i, int j)
    {
        var row = visited.ContainsKey(i) ? visited[i] : new Dictionary<int, bool>();
            row[j] = true;

        visited[i] = row;
    }
}