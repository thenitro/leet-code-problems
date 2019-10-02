using System;

namespace RandomPickWithWeight
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}

public class Solution
{
    private Random _random;
    private int[] _wSums;
    
    public Solution(int[] w)
    {
        _random = new Random();
        
        for (var i = 1; i < w.Length; i++)
        {
            w[i] += w[i - 1];
        }
        
        _wSums = w;
    }

    public int PickIndex()
    {
        var len = _wSums.Length;
        var idx = _random.Next(_wSums[len - 1]) + 1;
        
        var left = 0;
        var right = len - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;

            if (_wSums[mid] == idx)
            {
                return mid;
            }
            else if (_wSums[mid] < idx)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}