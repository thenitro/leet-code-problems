using System;

namespace KnightProbabilityInChessboard
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(0.0625 == new Solution().KnightProbability(3, 2, 0, 0));
        }
    }
}

public class Solution
{
    public double KnightProbability(int N, int K, int sr, int sc)
    {
        var dp = new double[N, N];
        
        var dr = new int[] {2, 2, 1, 1, -1, -1, -2, -2};
        var dc = new int[] {1, -1, 2, -2, 2, -2, 1, -1};

        dp[sr, sc] = 1;

        for (; K > 0; K--)
        {
            var dp2 = new double[N, N];
            
            for (var r = 0; r < N; r++)
            {
                for (var c = 0; c < N; c++)
                {
                    for (var k = 0; k < 8; k++)
                    {
                        var cr = r + dr[k];
                        var cc = c + dc[k];

                        if (0 <= cr && cr < N && 0 <= cc && cc < N)
                        {
                            dp2[cr, cc] += dp[r, c] / 8.0;
                        }
                    }
                }
            }

            dp = dp2;
        }

        var result = 0.0;

        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < N; j++)
            {
                result += dp[i, j];
            }
        }
        
        return result;
    }
}