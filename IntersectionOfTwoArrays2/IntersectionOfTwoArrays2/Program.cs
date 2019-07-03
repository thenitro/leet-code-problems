using System;
using System.Collections.Generic;

namespace IntersectionOfTwoArrays2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().Intersect(new []{1, 2, 2, 1}, new []{2,2});

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            result = new Solution().Intersect(new []{4, 9, 5}, new []{9,4,9,8,4});

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}

public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        var result = new List<int>();
        
        var dict1 = new Dictionary<int, int>();
        var dict2 = new Dictionary<int, int>();

        foreach (var i in nums1)
        {
            dict1[i] = dict1.ContainsKey(i) ? dict1[i] + 1 : 1;
        }
        
        foreach (var i in nums2)
        {
            dict2[i] = dict2.ContainsKey(i) ? dict2[i] + 1 : 1;
        }

        foreach (var key in dict1.Keys)
        {
            if (dict2.ContainsKey(key))
            {
                var times = Math.Min(dict1[key], dict2[key]);

                while (times > 0)
                {
                    result.Add(key);
                    times--;
                }
            }
        }

        return result.ToArray();
    }
}