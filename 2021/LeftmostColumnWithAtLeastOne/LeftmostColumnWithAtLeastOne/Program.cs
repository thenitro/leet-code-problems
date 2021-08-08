using System;
using System.Collections.Generic;

namespace LeftmostColumnWithAtLeastOne
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

class Solution
{
    public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix)
    {
        var dimensions = binaryMatrix.Dimensions();
        var rows = dimensions[0];
        var cols = dimensions[1];

        var minLeft = -1;

        for (var i = 0; i < rows; i++)
        {
            var leftMostIndex = GetNonZeroLeftIndex(i, cols, binaryMatrix);
            if (leftMostIndex != -1)
            {
                if (minLeft == -1)
                {
                    minLeft = leftMostIndex;
                }
                else
                {
                    minLeft = Math.Min(leftMostIndex, minLeft);
                }
            }
        }

        return minLeft;
    }

    private int GetNonZeroLeftIndex(int i, int cols, BinaryMatrix matrix)
    {
        var left = 0;
        var right = cols;
        var firstNonZero = -1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (matrix.Get(i, mid) == 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
                firstNonZero = mid;
            }
        }

        return firstNonZero;
    }
}

class BinaryMatrix
{
    public int Get(int row, int col)
    {
    }

    public IList<int> Dimensions()
    {
    }
}