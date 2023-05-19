using System;

public class Solution
{
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
        var result = new int[rowSum.Length][];

        for (var i = 0; i < rowSum.Length; i++)
        {
            result[i] = new int[colSum.Length];

            for (var j = 0; j < colSum.Length; j++)
            {
                result[i][j] = Math.Min(rowSum[i], colSum[j]);
                rowSum[i] -= result[i][j];
                colSum[j] -= result[i][j];
            }
        }

        return result;
    }
}