using System;

namespace UniquePaths
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().UniquePaths(3, 2));
            Console.WriteLine(28 == new Solution().UniquePaths(7, 3));
        }
    }
}

public class Solution
{
    public int UniquePaths(int m, int n)
    {
        var map = new int[m, n];

        for (var i = 0; i < m; i++)
        {
            map[i,0] = 1;
        }
        
        for (var j = 0; j < n; j++)
        {
            map[0,j] = 1;
        }

        for (var i = 1; i < m; i++)
        {
            for (var j = 1; j < n; j++)
            {
                map[i, j] = map[i - 1, j] + map[i, j - 1];
            }
        }
        
        return map[m-1,n-1];
    }
}