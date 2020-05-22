using System;
using System.Collections.Generic;
using System.Linq;

namespace SlidingWindowMedian
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //1, -1, -1, 3, 5, 6
            Console.WriteLine(
                string.Join(", ", new Solution().MedianSlidingWindow(new[] {1, 3, -1, -3, 5, 3, 6, 7}, 3)));
            //2147483647
            Console.WriteLine(
                string.Join(", ", new Solution().MedianSlidingWindow(new[] { 2147483647, 2147483647 }, 2)));
        }
    }
}

public class Solution
{
    public double[] MedianSlidingWindow(int[] nums, int k)
    {
        var N = nums.Length - k + 1;

        if (N <= 0)
        {
            return new double[0];
        }

        var result = new double[N];
        var sorted = new List<int>();

        for (var i = 0; i < N; i++)
        {
            if (i == 0)
            {
                for (var j = i; j < k; j++)
                {
                    InsertElement(sorted, nums[j]);
                }
            }

            if (i != 0)
            {
                sorted.Remove(nums[i - 1]);
                InsertElement(sorted, nums[i + k - 1]);
            }

            result[i] = FindMedian(sorted, k);
        }

        return result;
    }

    private void InsertElement(List<int> list, int value)
    {
        var index = 0;

        while (index < list.Count && value > list[index])
        {
            index++;
        }

        list.Insert(index, value);
    }

    private double FindMedian(List<int> sorted, int k)
    {
        if (k % 2 == 0)
        {
            return ((long)sorted.ElementAt(k / 2 - 1) + (long)sorted.ElementAt(k / 2)) / 2.0;
        }

        return sorted.ElementAt(k / 2);
    }
}