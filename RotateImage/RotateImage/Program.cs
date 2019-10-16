using System;

namespace RotateImage
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var matrix2x2 = new[]
            {
                new[] { 1, 2 },
                new[] { 3, 4 }
            };
            
            new Solution().Rotate(matrix2x2);

            for (int i = 0; i < matrix2x2.Length; i++)
            {
                for (int j = 0; j < matrix2x2[i].Length; j++)
                {
                    Console.Write(matrix2x2[i][j] + ", ");
                }
                
                Console.WriteLine();
            }
            
            var matrix4x4 = new[]
            {
                new[] { 1, 2, 3, 4 },
                new[] { 5, 6, 7, 8 },
                new[] { 9, 10, 11, 12 },
                new[] { 13, 14, 15, 16 },
            };
            
            new Solution().Rotate(matrix4x4);

            for (int i = 0; i < matrix4x4.Length; i++)
            {
                for (int j = 0; j < matrix4x4[i].Length; j++)
                {
                    Console.Write(matrix4x4[i][j].ToString("D2") + ", ");
                }
                
                Console.WriteLine();
            }
        }
    }
}

public class Solution {
    public void Rotate(int[][] matrix)
    {
        var s = 0;
        var e = matrix.Length - 1;

        while (s < e)
        {
            var tmp = matrix[s];
            
            matrix[s] = matrix[e];
            matrix[e] = tmp;
            
            s++;
            e--;
        }

        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = i + 1; j < matrix[i].Length; j++)
            {
                var tmp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = tmp;
            }
        }
    }
}