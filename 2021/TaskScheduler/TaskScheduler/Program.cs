using System;
using System.Collections.Generic;

namespace TaskScheduler
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(8 == new Solution().LeastInterval(new char[] { 'A','A','A','B','B','B' }, 2));
            Console.WriteLine(16 == new Solution().LeastInterval(new char[] { 'A','A','A','A','A','A','B','C','D','E','F','G' }, 2));
        }
    }
}

public class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        if (n == 0)
        {
            return tasks.Length;
        }

        var count = new int[26];
        var max = 0;
        var longest = 0;

        foreach (var task in tasks)
        {
            count[task - 'A']++;
            max = Math.Max(max, count[task - 'A']);
        }

        foreach (var i in count)
        {
            if (i == max)
            {
                longest++;
            }
        }

        var total = (max - 1) * (n + 1) + longest;
        return total > tasks.Length ? total : tasks.Length;
    }
}