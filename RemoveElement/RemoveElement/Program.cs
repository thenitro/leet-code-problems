using System;
using System.Collections.Generic;

namespace RemoveElement
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().RemoveElement(new int[] { 3, 2, 2, 3 }, 3));
            Console.WriteLine(5 == new Solution().RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2));
            Console.WriteLine(0 == new Solution().RemoveElement(new int[] { }, 2));
            Console.WriteLine(0 == new Solution().RemoveElement(new int[] { 2 }, 2));
            Console.WriteLine(0 == new Solution().RemoveElement(new int[] { 2, 2, 2, 2, 2 }, 2));
            Console.WriteLine(5 == new Solution().RemoveElement(new int[] { 1, 1, 1, 1, 1 }, 2));
        }
    }
}

public class Solution {
    public int RemoveElement(int[] nums, int val)
    {
        var freePlaces = new Queue<int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == val)
            {
                freePlaces.Enqueue(i);
            }
        }

        var result = nums.Length - freePlaces.Count;

        if (result > 0)
        {
            for (var i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i] != val && freePlaces.Count > 0)
                {
                    var newIndex = freePlaces.Dequeue();
                    nums[newIndex] = nums[i];
                }
            }
        }
        
        return result;
    }
}