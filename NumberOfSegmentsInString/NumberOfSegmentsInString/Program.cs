using System;

namespace NumberOfSegmentsInString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().CountSegments("Hello, my name is John"));
            Console.WriteLine(0 == new Solution().CountSegments(""));
            Console.WriteLine(0 == new Solution().CountSegments("                "));
        }
    }
}

public class Solution {
    public int CountSegments(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        var split = s.Split(' ');

        var count = 0;
        
        foreach (var c in split)
        {
            if (string.IsNullOrEmpty(c))
            {
                continue;
            }

            count++;
        }

        return count;
    }   
}