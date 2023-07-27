using System.Collections.Generic;

public class Solution
{
    public int ShortestPathAllKeys(string[] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var keyBit = new Dictionary<char, int>();
        var bitStart = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var keySymbol = grid[i][j];
                if (char.IsLower(keySymbol))
                {
                    keyBit.Add(keySymbol, bitStart++);
                }
            }
        }

        var maskEnd = (1 << bitStart) - 1;
        var maskSize = (1 << bitStart);

        var memo = new bool[m, n, maskSize];
        var start = new int[3];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == '@')
                {
                    start = new int[] { i, j, 0 };
                }
            }
        }

        var queue = new Queue<int[]>();
        queue.Enqueue(start);

        var step = 0;

        while (queue.Count > 0)
        {
            var size = queue.Count;

            for (var k = 0; k < size; k++)
            {
                var curr = queue.Dequeue();
                var row = curr[0];
                var col = curr[1];
                var mask = curr[2];

                if (row < 0 || row >= m || col < 0 || col >= n) continue;

                var currentChar = grid[row][col];
                if (currentChar == '#') continue;

                if (char.IsUpper(currentChar))
                {
                    if ((mask & (1 << keyBit[char.ToLower(currentChar)])) == 0) continue;
                }

                if (char.IsLower(currentChar))
                {
                    mask |= (1 << keyBit[currentChar]);
                }

                if (mask == maskEnd) return step;
                if (memo[row, col, mask]) continue;

                memo[row, col, mask] = true;

                queue.Enqueue(new[] { row + 1, col, mask });
                queue.Enqueue(new[] { row - 1, col, mask });
                queue.Enqueue(new[] { row, col + 1, mask });
                queue.Enqueue(new[] { row, col - 1, mask });
            }

            step++;
        }

        return -1;
    }
}