using System;

namespace ReshapeTheMatrix
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var matrix1 = new Solution().MatrixReshape(new int[][]
            {
                new[] {1, 2},
                new[] {3, 4},
            }, 1, 4);

            PrintMatrix(matrix1);
            
            var matrix2 = new Solution().MatrixReshape(new int[][]
            {
                new[] {1, 2},
                new[] {3, 4},
            }, 2, 4);

            PrintMatrix(matrix2);
            
            var matrix3 = new Solution().MatrixReshape(new int[][]
            {
                new[] {1, 2},
                new[] {3, 4},
            }, 4, 1);

            PrintMatrix(matrix3);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] +  " ");
                }

                Console.WriteLine();
            }
        }
    }
}

public class Solution
{
    public int[][] MatrixReshape(int[][] nums, int r, int c)
    {
        if (r * c > nums.Length * nums[0].Length)
        {
            return nums;
        }

        var result = new int[r][];
            result[0] = new int[c];

        var ri = 0;
        var rj = 0;
        
        for (var i = 0; i < nums.Length; i++) 
        {
            for (var j = 0; j < nums[i].Length; j++)
            {
                result[ri][rj] = nums[i][j];
                
                rj++;

                if (rj == c)
                {
                    rj = 0;
                    ri++;

                    if (ri < r)
                    {
                        result[ri] = new int[c];
                    }
                }
            }
        }

        return result;
    }
}