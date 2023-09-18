using System;
using System.Collections.Generic;

public class Solution
{
    public IList<string> SummaryRanges(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return new List<string>();
        }
        
        long start = nums[0];
        long prev = start;
        
        long end = 0;
        
        var skippedAmount = 1;
        
        var result = new List<string>();

        for (var i = 1; i < nums.Length; i++)
        {
            var candidate = nums[i];
            
            if (Math.Abs(candidate - prev) > 1)
            {
                Add(skippedAmount, start, end, result);

                start = candidate;
                skippedAmount = 1;
            }
            else
            {
                end = candidate;
                skippedAmount++;
            }

            prev = candidate;
        }
        
        Add(skippedAmount, start, prev, result);

        return result;
    }

    private void Add(int skippedAmount, long start, long end, List<string> result)
    {
        if (skippedAmount == 1)
        {
            result.Add($"{start}");
        }
        else
        {
            result.Add($"{start}->{end}");
        }
    }
}