using System;
using System.Collections.Generic;

public class Solution
{
    public int MaximumBeauty(int[] nums, int k)
    {
        var list = new List<int>(nums);
        list.Sort();

        var start = 0;
        var result = 0;

        for (var i = 0; i < list.Count; i++)
        {
            while (list[i] - list[start] > 2 * k)
            {
                start++;
            }

            result = Math.Max(result, i - start + 1);
        }

        return result;
    }
}