using System;
using System.Runtime.Remoting.Messaging;

namespace GameOfLife
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = new[]
            {
                new[] {0, 1, 0},
                new[] {0, 0, 1},
                new[] {1, 1, 1},
                new[] {0, 0, 0},
            };

            new Solution().GameOfLife(input);

            foreach (var i in input)
            {
                Console.WriteLine(string.Join(", ", i));
            }
        }
    }
}

public class Solution
{
    public void GameOfLife(int[][] board)
    {
        var copy = new int[board.Length][];

        for (var i = 0; i < board.Length; i++)
        {
            copy[i] = new int[board[i].Length];

            for (int j = 0; j < board[i].Length; j++)
            {
                copy[i][j] = board[i][j];
            }
        }

        for (int i = 0; i < copy.Length; i++)
        {
            for (int j = 0; j < copy[i].Length; j++)
            {
                board[i][j] = CalculateCell(copy, i, j);
            }
        }
    }

    private int CalculateCell(int[][] board, int y, int x)
    {
        var count = 0;

        for (var i = y - 1; i < y + 2; i++)
        {
            for (var j = x - 1; j < x + 2; j++)
            {
                if (i == y && j == x)
                {
                    continue;
                }

                if (i < 0 || j < 0 || i >= board.Length || j >= board[y].Length)
                {
                    continue;
                }
                
                if (board[i][j] == 1)
                {
                    count++;
                }
            }
        }

        if (board[y][x] == 0)
        {
            return count == 3 ? 1 : 0;
        }

        if (count == 2 || count == 3)
        {
            return 1;
        }

        return 0;
    }
}