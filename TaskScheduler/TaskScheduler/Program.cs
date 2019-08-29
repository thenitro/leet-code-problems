using System;
using System.Collections.Generic;

namespace TaskScheduler
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(8 == new Solution().LeastInterval(new []{ 'A', 'A', 'A', 'B', 'B', 'B' }, 2));
            Console.WriteLine(6 == new Solution().LeastInterval(new []{ 'A', 'A', 'A', 'B', 'B', 'B' }, 0));
            Console.WriteLine(104 == new Solution().LeastInterval(new []{ 'A', 'A', 'A', 'B', 'B', 'B' }, 50));
        }
    }
}

public class Solution {
    public int LeastInterval(char[] tasks, int n)
    {
        var map = new int[26];

        foreach (var c in tasks)
        {
            map[c - 'A']++;
        }
        
        Array.Sort(map);

        var maxVal = map[25] - 1;
        var idleSlots = maxVal * n;

        for (int i = 24; i >= 0; i--)
        {
            idleSlots -= Math.Min(map[i], maxVal);
        }

        return idleSlots > 0 ? idleSlots + tasks.Length : tasks.Length;
    }
}