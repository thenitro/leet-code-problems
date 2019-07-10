using System;
using System.Collections.Generic;

namespace FirstUniqueCharacterInString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(0 == new Solution().FirstUniqChar("leetcode"));
            Console.WriteLine(2 == new Solution().FirstUniqChar("loveleetcode"));
            Console.WriteLine(-1 == new Solution().FirstUniqChar(""));
        }
    }
}

public class Solution {
    public int FirstUniqChar(string s)
    {
        var dictionary = new Dictionary<char, int>();

        foreach (var c in s)
        {
            dictionary[c] = dictionary.ContainsKey(c) ? dictionary[c] + 1 : 1;
        }

        foreach (var kv in dictionary)
        {
            if (kv.Value == 1)
            {
                return s.IndexOf(kv.Key);
            }
        }

        return -1;
    }
}