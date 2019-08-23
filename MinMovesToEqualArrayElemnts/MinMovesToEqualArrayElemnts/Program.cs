using System;

namespace MinMovesToEqualArrayElemnts
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().MinMoves(new[] {1, 2, 3}));
        }
    }
}

public class Solution
{
    public int MinMoves(int[] nums)
    {
        if (nums.Length < 2)
        {
            return 0;
        }

        var min = int.MaxValue;
        var sum = 0;

        foreach (var num in nums)
        {
            sum += num;
            min = Math.Min(min, num);
        }

        return sum - min * nums.Length;
    }
}