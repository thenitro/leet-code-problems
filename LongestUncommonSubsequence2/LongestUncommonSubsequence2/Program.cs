using System;
using System.Collections.Generic;

namespace LongestUncommonSubsequence2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().FindLUSlength(new[] {"aba", "cdc", "eae"}));
            Console.WriteLine(-1 == new Solution().FindLUSlength(new[] {"aaa", "aaa", "aa"}));
            Console.WriteLine(2 == new Solution().FindLUSlength(new[] {"aabbcc", "aabbcc", "cb"}));
            Console.WriteLine(2 == new Solution().FindLUSlength(new[] {"aabbcc", "aabbcc", "cb", "abc"}));
        }
    }
}

public class Solution
{
    public int FindLUSlength(string[] strs)
    {
        Array.Sort(strs, Compare);

        var duplicates = new HashSet<string>();
        var set = new HashSet<string>();

        foreach (var str in strs)
        {
            if (set.Contains(str))
            {
                duplicates.Add(str);
            }
            else
            {
                set.Add(str);
            }
        }
        
        for (var i = 0; i < strs.Length; i++)
        {
            if (duplicates.Contains(strs[i]))
            {
                continue;
            }

            if (i == 0)
            {
                return strs[0].Length;
            }
            
            for (var j = 0; j < i; j++)
            {
                if (IsSubsequence(strs[j], strs[i]))
                {
                    break;
                }
                
                if (j == i - 1)
                {
                    return strs[i].Length;
                }
            }
        }
        
        return -1;
    }

    private int Compare(string x, string y)
    {
        return y.Length - x.Length;
    }

    private bool IsSubsequence(string x, string y)
    {
        var indexX = 0;
        var indexY = 0;
        
        while (indexX < x.Length && indexY < y.Length)
        {
            if (x[indexX] == y[indexY])
            {
                indexY++;
            }

            indexX++;
        }

        return indexY == y.Length;
    }
}