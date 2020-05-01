using System;
using System.Collections.Generic;

namespace NumberOfPathsWithMaxScore
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().PathsWithMaxScore(new List<string>() { "E23", "2X2", "12S" })));
            Console.WriteLine(string.Join(",", new Solution().PathsWithMaxScore(new List<string>() { "E12", "1X1", "21S" })));
            Console.WriteLine(string.Join(",", new Solution().PathsWithMaxScore(new List<string>() { "E11", "XXX", "11S" })));
        }
    }
}

public class Solution
{
    private static readonly int[][] DIRS = new int[][]
    {
        new int[] { 0, -1 }, 
        new int[] { -1, 0 }, 
        new int[] { -1, -1 }, 
    };

    public int[] PathsWithMaxScore(IList<string> board)
    {
        var n = board.Count;
        var m = board[0].Length;

        var dpSum = new int[n, m];
        var dpCount = new int[n, m];

        dpCount[n - 1, m - 1] = 1;

        for (var r = m - 1; r >= 0; r--)
        {
            for (var c = n - 1; c >= 0; c--)
            {
                if (dpCount[r, c] == 0)
                {
                    continue;
                }

                foreach (var directions in DIRS)
                {
                    var nr = r + directions[0];
                    var nc = c + directions[1];

                    if (nr >= 0 && nc >= 0 && board[nr][nc] != 'X')
                    {
                        var nsum = dpSum[r, c];

                        if (board[nr][nc] != 'E')
                        {
                            nsum += board[nr][nc] - '0';
                        }

                        if (nsum > dpSum[nr, nc])
                        {
                            dpCount[nr, nc] = dpCount[r, c];
                            dpSum[nr, nc] = nsum;
                        } 
                        else if (nsum == dpSum[nr, nc])
                        {
                            dpCount[nr, nc] = (dpCount[nr, nc] + dpCount[r, c]) % 1000000007;
                        }
                    }
                }
            }
        }

        return new int[] {dpSum[0, 0], dpCount[0, 0]};
    }
}