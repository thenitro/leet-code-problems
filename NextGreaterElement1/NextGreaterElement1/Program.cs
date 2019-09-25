using System;
using System.Collections.Generic;

namespace NextGreaterElement1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().NextGreaterElement(new[] {4, 1, 2}, new[] {1, 3, 4, 2});
            Console.WriteLine(string.Join(",", result));
            var result2 = new Solution().NextGreaterElement(new[] {2, 4}, new[] {1, 2, 3, 4});
            Console.WriteLine(string.Join(",", result2));
        }
    }
}

public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var map = new Dictionary<int, int>();
        var stack = new Stack<int>();

        foreach (var num in nums2)
        {
            while (stack.Count != 0 && stack.Peek() < num)
            {
                map[stack.Pop()] = num;
            }
            
            stack.Push(num);
        }

        for (var i = 0; i < nums1.Length; i++)
        {
            nums1[i] = map.ContainsKey(nums1[i]) ? map[nums1[i]] : -1;
        }

        return nums1;
    }
}