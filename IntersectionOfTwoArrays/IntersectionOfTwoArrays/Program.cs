using System;
using System.Collections.Generic;

namespace IntersectionOfTwoArrays
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().Intersection(new []{1, 2, 2, 1}, new []{2,2});

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            
            result = new Solution().Intersection(new []{4, 9, 5}, new []{9,4,9,8,4});

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}

public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        var result = new List<int>();

        for (var i = 0; i < nums1.Length; i++)
        {
            var iElement = nums1[i];
            
            for (int j = 0; j < nums2.Length; j++)
            {
                if (iElement == nums2[j] && result.IndexOf(iElement) == -1)
                {
                    result.Add(iElement);
                }
            }
        }

        return result.ToArray();
    }
}