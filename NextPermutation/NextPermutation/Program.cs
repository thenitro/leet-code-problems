using System;

namespace NextPermutation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var arr = new int[] {1, 2, 3};
            new Solution().NextPermutation(arr);

            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            arr = new int[] {3, 2, 1};
            new Solution().NextPermutation(arr);

            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            arr = new int[] {1, 1, 5};
            new Solution().NextPermutation(arr);

            foreach (var i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            arr = new int[] {1, 3, 2};
            new Solution().NextPermutation(arr);

            foreach (var i in arr)//2 1 3
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}

public class Solution
{
    public void NextPermutation(int[] nums)
    {
        var i = nums.Length - 2;
        while (i >= 0 && nums[i + 1] <= nums[i])
        {
            i--;
        }

        if (i >= 0)
        {
            var j = nums.Length - 1;
            while (j >= 0 && nums[j] <= nums[i])
            {
                j--;
            }

            Swap(nums, i, j);
        }

        Reverse(nums, i + 1);
    }

    private void Swap(int[] nums, int i, int j)
    {
        var temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    private void Reverse(int[] nums, int start)
    {
        var i = start;
        var j = nums.Length - 1;

        while (i < j)
        {
            Swap(nums, i, j);
            i++;
            j--;
        }
    }
}