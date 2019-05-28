using System;
using System.Runtime.Remoting.Lifetime;

namespace MergeSortedArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var num1 = new int[] {1, 2, 3, 0, 0, 0};
            
            new Solution().Merge(num1, 3, new int[] { 2, 5, 6 }, 3);
            
            foreach (var i in num1)
            {
                Console.Write(i + ", ");
            }
        }
    }
}

public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        for (var i = 0; i < n; i++)
        {
            var element2 = nums2[i];
            var putIndex = FindPutIndex(nums1, m, element2);

            for (var k = nums1.Length - 1; k > putIndex; k--)
            {
                nums1[k] = nums1[k - 1];
            }

            nums1[putIndex] = element2;
            
            m++;
        }
    }

    private int FindPutIndex(int[] nums, int size, int element)
    {
        var l = 0;
        var r = size;

        while (l < r)
        {
            var middle = (l + r) / 2;
            
            if (element > nums[middle])
            {
                l = middle + 1;
            }
            else
            {
                r = middle;
            }
        }

        return l;
    }
}