using System;
using System.Linq;

namespace MedianOfTwoSortedArrays
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().FindMedianSortedArrays(new int[] {1, 2}, new int[] { 3, 4 }));
            Console.WriteLine(new Solution().FindMedianSortedArrays(new int[] {1, 3}, new int[] { 2 }));
            Console.WriteLine(new Solution().FindMedianSortedArrays(new int[] {}, new int[] { 1 }));
            Console.WriteLine(new Solution().FindMedianSortedArrays(new int[] { 2 }, new int[] {}));
            Console.WriteLine(new Solution().FindMedianSortedArrays(new int[] { 1 }, new int[] { 1 }));
            Console.WriteLine(new Solution().FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { -1, 3 }));
        }
    }
}

public class Solution {
    
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var totalLength = nums1.Length + nums2.Length;
            
        var allNums = new int[totalLength];
        
        Array.Copy(nums1, allNums, nums1.Length);
        Array.Copy(nums2, 0, allNums, nums1.Length, nums2.Length);
        Array.Sort(allNums);
        
        var halfLength = totalLength / 2;
        
        if (totalLength % 2 == 0)
        {
            return (allNums[halfLength - 1] + allNums[halfLength]) / 2.0;
        }

        return allNums[halfLength];
    }
}