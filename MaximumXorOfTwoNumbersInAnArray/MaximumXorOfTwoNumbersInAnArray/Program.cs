using System;
using System.Collections.Generic;

namespace MaximumXorOfTwoNumbersInAnArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(28 == new Solution().FindMaximumXOR(new []{ 3, 10, 5, 25, 2, 8 }));
            Console.WriteLine(0 == new Solution().FindMaximumXOR(new []{ 0 }));
        }
    }
}

public class Solution {
    public int FindMaximumXOR(int[] nums)
    {
        var max = 0;
        var mask = 0;


        for (var i = 31; i >= 0; i--)
        {
            mask = mask | (1 << i);
            
            var set = new HashSet<int>();
            foreach (var num in nums)
            {
                set.Add(num & mask);
            }

            var tmp = max | (1 << i);

            foreach (var prefix in set)
            {
                if (set.Contains(tmp ^ prefix))
                {
                    max = tmp;
                    break;
                }
            }
        }

        return max;
    }
}