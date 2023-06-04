using System;

public class Solution
{
    public int MatrixSum(int[][] nums)
    {
        var result = 0;
        var count = 0;

        while (count < Math.Max(nums.Length, nums[0].Length))
        {
            var biggest = int.MinValue;
            
            for (var row = 0; row < nums.Length; row++)
            {
                var biggestInCol = int.MinValue;
                var biggestIndex = new int[2];

                for (var col = 0; col < nums[row].Length; col++)
                {
                    if (biggestInCol <= nums[row][col])
                    {
                        biggestInCol = nums[row][col];
                        
                        biggestIndex[0] = row;
                        biggestIndex[1] = col;
                    }
                }

                nums[biggestIndex[0]][biggestIndex[1]] = 0;
                biggest = Math.Max(biggest, biggestInCol);
            }

            result += biggest;
            count++;
        }

        return result;
    }
}