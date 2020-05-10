using System;

namespace PartitionArrayIntoDisjointIntervals
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().PartitionDisjoint(new[] {5, 0, 3, 8, 6}));
            Console.WriteLine(4 == new Solution().PartitionDisjoint(new[] {1, 1, 1, 0, 6, 12}));
            Console.WriteLine(1 == new Solution().PartitionDisjoint(new[] {1, 1}));
            Console.WriteLine(1 == new Solution().PartitionDisjoint(new[] {26, 51, 40, 58, 42, 76, 30, 48, 79, 91}));
        }
    }
}

public class Solution
{
    public int PartitionDisjoint(int[] A)
    {
        var N = A.Length;

        var maxLeft = new int[N];
        var minRight = new int[N];

        var m = A[0];
        for (var i = 0; i < N; i++)
        {
            m = Math.Max(m, A[i]);
            maxLeft[i] = m;
        }
        
        m = A[N - 1];
        for (var i = N - 1; i >= 0; i--)
        {
            m = Math.Min(m, A[i]);
            minRight[i] = m;
        }
        
        for (var i = 1; i < N; i++)
        {
            if (maxLeft[i - 1] <= minRight[i])
            {
                return i;
            }
        }
        
        return 0;
    }
}