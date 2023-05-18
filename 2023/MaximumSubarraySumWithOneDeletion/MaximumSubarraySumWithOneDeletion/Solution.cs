using System;

public class Solution
{
    public int MaximumSum(int[] arr)
    {
        var size = arr.Length;
        if (size == 1) return arr[0];

        var dropped = Math.Max(arr[0], arr[1]);
        var notDropped = Math.Max(arr[0] + arr[1], arr[1]);

        var answer = Math.Max(dropped, notDropped);
        
        for (var i = 2; i < size; i++)
        {
            dropped = Math.Max(notDropped, arr[i] + dropped);
            notDropped = Math.Max(notDropped + arr[i], arr[i]);
            answer = Math.Max(answer, Math.Max(dropped, notDropped));
        }

        return answer;
    }
}