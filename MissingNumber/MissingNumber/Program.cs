using System;

namespace MissingNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().MissingNumber(new []{3, 0, 1}));
            Console.WriteLine(8 == new Solution().MissingNumber(new []{9,6,4,2,3,5,7,0,1}));
        }
    }
}

public class Solution {
    public int MissingNumber(int[] nums)
    {
        var map = new int[nums.Length + 1];

        for (var i = 0; i < nums.Length; i++)
        {
            var n = nums[i];
            map[n] = -1;
        }

        for (var i = 0; i < map.Length; i++)
        {
            if (map[i] == -1)
            {
                continue;
            }
            
            return i;
        }

        return 0;
    }
}