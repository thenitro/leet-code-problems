using System;

namespace ImplementStrStr
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().StrStr("hello", "ll"));
            Console.WriteLine(-1 == new Solution().StrStr("aaaaa", "baa"));
            Console.WriteLine(0 == new Solution().StrStr("aaaaa", ""));
            Console.WriteLine(-1 == new Solution().StrStr("aa", "aaa"));
            Console.WriteLine(-1 == new Solution().StrStr("", "a"));
            Console.WriteLine(0 == new Solution().StrStr("", ""));
            Console.WriteLine(-1 == new Solution().StrStr("mississippi", "issipi"));
            Console.WriteLine(9 == new Solution().StrStr("mississippi", "pi"));
            Console.WriteLine(-1 == new Solution().StrStr("mississippi", "sippia"));
        }
    }
}

public class Solution {
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle))
        {
            return 0;
        }
        
        if (string.IsNullOrEmpty(haystack) || needle.Length > haystack.Length)
        {
            return -1;
        }
        
        var index = -1;
        var indexN = 0;

        for (int i = 0; i < haystack.Length; i++)
        {
            if (needle.Length - indexN > haystack.Length - i)
            {
                return -1;
            }
            
            if (haystack[i] == needle[indexN])
            {
                if (index == -1)
                {
                    index = i;
                }
                
                indexN++;

                if (indexN > needle.Length - 1)
                {
                    return index;
                }
            }
            else
            {
                if (index != -1)
                {
                    i = index;
                }
                
                index = -1;
                indexN = 0;
            }
        }
        
        return indexN == needle.Length - 1 ? index : -1;
    }
}