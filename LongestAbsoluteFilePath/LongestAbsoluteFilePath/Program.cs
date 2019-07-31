using System;
using System.Collections.Generic;

namespace LongestAbsoluteFilePath
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(20 == new Solution().LengthLongestPath("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"));
            Console.WriteLine(32 == new Solution().LengthLongestPath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"));
        }
    }
}

public class Solution {
    public int LengthLongestPath(string input)
    {
        var stack = new Stack<int>();
            stack.Push(0);

        var maxLength = 0;

        foreach (var str in input.Split('\n'))
        {
            var level = str.LastIndexOf("\t") + 1;
            
            while (level + 1 < stack.Count)
            {
                stack.Pop();
            }

            var length = stack.Peek() + str.Length - level + 1;
            stack.Push(length);
            
            if (str.Contains("."))
            {
                maxLength = Math.Max(maxLength, length - 1);
            }
        }
        
        return maxLength;
    }
}