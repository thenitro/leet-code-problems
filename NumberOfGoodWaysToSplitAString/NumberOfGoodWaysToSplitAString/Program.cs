using System;
using System.Collections.Generic;

namespace NumberOfGoodWaysToSplitAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().NumSplits("aacaba"));
            Console.WriteLine(1 == new Solution().NumSplits("abcd"));
            Console.WriteLine(4 == new Solution().NumSplits("aaaaa"));
            Console.WriteLine(2 == new Solution().NumSplits("acbadbaada"));
        }
    }
}

public class Solution
{
    public int NumSplits(string s)
    {
        var result = 0;
        
        var left = new Dictionary<char, int>();
        var right = new Dictionary<char, int>();

        for (var i = 0; i < s.Length; i++)
        {
            Add(right, s[i]);
        }

        for (var i = 0; i < s.Length; i++)
        {
            Add(left, s[i]);
            Remove(right, s[i]);

            if (left.Count == right.Count)
            {
                result++;
            }
        }

        return result;
    }

    private void Add(Dictionary<char, int> dict, char c)
    {
        if (dict.ContainsKey(c))
        {
            dict[c]++;
        }
        else
        {
            dict[c] = 1;
        }
    }

    private void Remove(Dictionary<char, int> dict, char c)
    {
        if (!dict.ContainsKey(c))
        {
            return;
        }

        dict[c]--;

        if (dict[c] <= 0)
        {
            dict.Remove(c);
        }
    }
}