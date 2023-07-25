using System;
public class Solution
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        var n = intervals.Length;
        Array.Sort(intervals, (ints, ints1) => ints[1].CompareTo(ints1[1]));

        var prev = 0;
        var count = 1;

        for (var i = 1; i < n; i++)
        {
            if (intervals[i][0] >= intervals[prev][1])
            {
                prev = i;
                count++;
            }
        }

        return n - count;
    }
}