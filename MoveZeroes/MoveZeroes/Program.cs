using System;

namespace MoveZeroes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var arr = new int[] {0, 1, 0, 3, 12};

            new Solution().MoveZeroes(arr);

            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
            
            arr = new int[] {0, 0, 1};

            new Solution().MoveZeroes(arr);

            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
        }
    }
}

public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        var zeroOffset = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > nums.Length - zeroOffset)
            {
                return;
            }
            
            if (nums[i] == 0)
            {
                var j = i;
                
                while (j < nums.Length - zeroOffset)
                {
                    nums[j] = nums[j + 1];
                    j++;
                }
                
                nums[nums.Length - zeroOffset] = 0;
                
                zeroOffset++;

                i--;
            }
        }
    }
}