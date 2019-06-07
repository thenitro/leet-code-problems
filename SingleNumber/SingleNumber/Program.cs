using System;
using System.Collections.Generic;
using System.Linq;

namespace SingleNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().SingleNumber(new []{2, 2, 1}));
            Console.WriteLine(4 == new Solution().SingleNumber(new []{4, 1, 2, 1, 2}));
        }
    }
}

public class Solution {
    public int SingleNumber(int[] nums)
    {
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            dict[num] = dict.ContainsKey(num) ? dict[num] + 1 : 1;
        }

        return dict.Aggregate((x,y) => x.Value < y.Value ? x : y).Key;
    }
}