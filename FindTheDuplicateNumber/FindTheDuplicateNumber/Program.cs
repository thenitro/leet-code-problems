using System;

namespace FindTheDuplicateNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().FindDuplicate(new[] {1, 3, 4, 2, 2}));
            Console.WriteLine(3 == new Solution().FindDuplicate(new[] {3, 1, 3, 4, 2}));
        }
    }
}

public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        var tortoise = nums[0];
        var hare = nums[0];

        do
        {
            tortoise = nums[tortoise];
            hare = nums[nums[hare]];
        } while (tortoise != hare);
        
        var ptr1 = nums[0];
        var ptr2 = tortoise;

        while (ptr1 != ptr2)
        {
            ptr1 = nums[ptr1];
            ptr2 = nums[ptr2];
        }

        return ptr1;
    }
}