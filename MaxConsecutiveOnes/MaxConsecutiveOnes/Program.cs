using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxConsecutiveOnes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().FindMaxConsecutiveOnes(new[] {1, 1, 0, 1, 1, 1}));
            Console.WriteLine(2 == new Solution().FindMaxConsecutiveOnes(new[] {1, 0, 1, 1, 0, 1}));
        }
    }
}

public class Solution
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var count = 0;
        var arr = new List<int>();
        
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                count++;
            }
            else
            {
                arr.Add(count);
                count = 0;
            }
        }
        
        arr.Add(count);

        return arr.Max();
    }
}