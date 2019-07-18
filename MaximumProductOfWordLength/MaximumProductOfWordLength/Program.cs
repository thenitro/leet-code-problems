using System;
using System.Collections.Generic;

namespace MaximumProductOfWordLength
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(16 == new Solution().MaxProduct(new[] {"abcw", "baz", "foo", "bar", "xftn", "abcdef"}));
            Console.WriteLine(4 == new Solution().MaxProduct(new[] {"a", "ab", "abc", "d", "cd", "bcd", "abcd"}));
            Console.WriteLine(0 == new Solution().MaxProduct(new[] {"a", "aa", "aaa", "aaaa"}));
        }
    }
}

public class Solution
{
    public int MaxProduct(string[] words)
    {
        if (words == null || words.Length == 0)
        {
            return 0;
        }

        var len = words.Length;
        var value = new int[len];

        for (var i = 0; i < len; i++)
        {
            var tmp = words[i];
            value[i] = 0;
            for (var j = 0; j < tmp.Length; j++)
            {
                value[i] |= 1 << (tmp[j] - 'a');
            }
        }

        int maxProduct = 0;

        for (var i = 0; i < len; i++)
        {
            for (var j = i + 1; j < len; j++)
            {
                if ((value[i] & value[j]) == 0 && (words[i].Length * words[j].Length > maxProduct))
                {
                    maxProduct = words[i].Length * words[j].Length;
                }
            }
        }

        return maxProduct;
    }
}