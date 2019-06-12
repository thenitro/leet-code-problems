using System;
using System.Collections.Generic;

namespace MajorityElement
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().MajorityElement(new int[] { 3, 2, 3, }));
            Console.WriteLine(2 == new Solution().MajorityElement(new int[] { 2, 2, 1, 1, 1, 2, 2, }));
            Console.WriteLine(7 == new Solution().MajorityElement(new int[] { 8,8,7,7,7 }));
        }
    }
}

public class Solution {
    public int MajorityElement(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        var length = nums.Length;
        var halfLength = (int)Math.Ceiling(length / 2.0);
        
        for (var i = 0; i < length; i++)
        {
            var val = nums[i];
            var count = dict.ContainsKey(val) ? dict[val] + 1 : 1;
            dict[val] = count;
            
            if (count >= halfLength)
            {
                return val;
            }
        }
        
        return 0;
    }
}