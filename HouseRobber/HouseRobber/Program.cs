using System;

namespace HouseRobber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(4 == new Solution().Rob(new int[] { 1, 2, 3, 1}));
            Console.WriteLine(12 == new Solution().Rob(new int[] { 2, 7, 9, 3, 1}));
            Console.WriteLine(4 == new Solution().Rob(new int[] { 2, 1, 1, 2}));
            Console.WriteLine(5 == new Solution().Rob(new int[] { 2, 1, 1, 1, 2}));
            Console.WriteLine(7 == new Solution().Rob(new int[] { 3, 1, 1, 1, 1, 3}));
        }
    }
}

public class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 0) return 0;

        var prev1 = 0;
        var prev2 = 0;

        foreach (var num in nums)
        {
            var tmp = prev1;
            prev1 = Math.Max(prev2 + num, prev1);
            prev2 = tmp;
        }

        return prev1;
    }
}