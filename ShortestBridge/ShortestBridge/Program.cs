using System;

namespace ShortestBridge
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == 
                              new Solution().ShortestBridge(
                                  new[]
                                  {
                                      new[] {0, 1}, 
                                      new[] {1, 0}
                                  }));
            
            Console.WriteLine(2 == 
                              new Solution().ShortestBridge(
                                  new[]
                                  {
                                      new[] {0,1,0}, 
                                      new[] {0,0,0},
                                      new[] {0,0,1}
                                  }));
        }
    }
}

public class Solution
{
    public int ShortestBridge(int[][] A)
    {
        var found = 0;
        for (var i = 0; found == 0 && i < A.Length; i++)
        {
            for (var j = 0; found == 0 && j < A[i].Length; j++)
            {
                found = Paint(A, i, j);
            }
        }

        for (var cl = 2; ;cl++)
        {
            for (var i = 0; i < A.Length; i++)
            {
                for (var j = 0; j < A[i].Length; j++)
                {
                    if (A[i][j] == cl && ((Expand(A, i - 1, j, cl) || Expand(A, i + 1, j, cl) ||
                                           Expand(A, i, j + 1, cl) || Expand(A, i, j - 1, cl))))
                    {
                        return cl - 2;
                    }
                }
            }
        }
    }

    private bool Expand(int[][] A, int i, int j, int cl)
    {
        if (i < 0 || j < 0 || i >= A.Length || j >= A[i].Length)
        {
            return false;
        }

        if (A[i][j] == 0)
        {
            A[i][j] = cl + 1;
        }

        return A[i][j] == 1;
    }

    private int Paint(int[][] A, int i, int j)
    {
        if (i < 0 || j < 0 || i >= A.Length || j >= A[i].Length || A[i][j] != 1)
        {
            return 0;
        }

        A[i][j] = 2;

        return 1 + Paint(A, i + 1, j) + Paint(A, i - 1, j) + Paint(A, i, j + 1) + Paint(A, i, j - 1);
    }
}