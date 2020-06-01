using System;
using System.Collections.Generic;

namespace FindSmallestLetterGreaterThanTarget
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine('c' == new Solution().NextGreatestLetter(new[] {'c', 'f', 'j'}, 'a'));
        }
    }
}

public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        var lo = 0;
        var hi = letters.Length;

        while (lo < hi)
        {
            var mid = lo + (hi - lo) / 2;

            if (letters[mid] <= target)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid;
            }
        }

        return letters[lo % letters.Length];
    }
}