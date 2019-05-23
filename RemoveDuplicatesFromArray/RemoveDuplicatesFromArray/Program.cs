using System;

namespace RemoveDuplicatesFromArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var arr = new int[] {1, 1, 2};

            Console.WriteLine(new Solution().RemoveDuplicates(arr));
            
            PrintArr(arr);
            
            var arr2 = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

            Console.WriteLine(new Solution().RemoveDuplicates(arr2));
            
            PrintArr(arr2);
            
            var arr3 = new int[] { };

            Console.WriteLine(new Solution().RemoveDuplicates(arr3));
            
            PrintArr(arr3);
            
            var arr4 = new int[] { 0 };

            Console.WriteLine(new Solution().RemoveDuplicates(arr4));
            
            PrintArr(arr4);
        }

        private static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            
            Console.WriteLine();
        }
    }
}

public class Solution {
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        
        var len = 1;
        var startIndex = 1;
        var c = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] != c)
            {
                nums[len] = nums[i];
                startIndex = i;

                c = nums[i];
                len++;
            }
        }

        return len;
    }
}