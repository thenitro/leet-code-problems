using System;
using System.Collections.Generic;

namespace ShortestSubarrayWithSumAtLeastK
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(1 == new Solution().ShortestSubarray(new[] {1}, 1));
            Console.WriteLine(-1 == new Solution().ShortestSubarray(new[] {1, 2}, 4));
            Console.WriteLine(3 == new Solution().ShortestSubarray(new[] {2, -1, 2}, 3));
            Console.WriteLine(2 == new Solution().ShortestSubarray(new[] { 17,85,93,-45,-21 }, 150));
        }
    }
}

public class Solution
{
    public int ShortestSubarray(int[] A, int K)
    {
        var N = A.Length;
        var p = new long[N + 1];

        for (var i = 0; i < N; i++)
        {
            p[i + 1] = p[i] + A[i];
        }

        var result = N + 1;
        var monoq = new LinkedList<int>();

        for (var i = 0; i < p.Length; i++)
        {
            while (monoq.Count != 0 && p[i] <= p[monoq.Last.Value])
            {
                monoq.RemoveLast();
            }

            while (monoq.Count != 0 && p[i] >= p[monoq.First.Value] + K)
            {
                result = Math.Min(result, i - monoq.First.Value);
                monoq.RemoveFirst();
            }

            monoq.AddLast(i);
        }

        return result < N + 1 ? result : -1;
    }
}