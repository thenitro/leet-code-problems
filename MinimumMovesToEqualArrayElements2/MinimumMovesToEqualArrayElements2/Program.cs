using System;

namespace MinimumMovesToEqualArrayElements2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write(2 == new Solution().MinMoves2(new []{ 1, 2, 3}));
        }
    }
}

public class Solution {
    public int MinMoves2(int[] nums)
    {
        var sum = 0;
        var median = QuickSelect(nums, nums.Length / 2 + 1, 0, nums.Length - 1);

        for (int i = 0; i < nums.Length; i++)
        {
            sum += Math.Abs(nums[i] - median);
        }

        return sum;
    }

    private int QuickSelect(int[] nums, int k, int start, int end)
    {
        var l = start;
        var r = end;
        var pivot = nums[(l + r) / 2];

        while (l <= r)
        {
            while (nums[l] < pivot)
            {
                l++;
            }

            while (nums[r] > pivot)
            {
                r--;
            }
            
            if (l >= r)
            {
                break;
            }

            Swap(nums, l++, r--);
        }

        if (l - start + 1 > k)
        {
            return QuickSelect(nums, k, start, l - 1);
        }

        if (l - start + 1 == k && l == r)
        {
            return nums[l];
        }

        return QuickSelect(nums, k - r + start - 1, r + 1, end);
    }

    private void Swap(int[] nums, int i, int j)
    {
        var tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }
}