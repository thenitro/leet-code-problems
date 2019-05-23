using System;

namespace LongestCommonPrefix
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("fl == {0}", new Solution().LongestCommonPrefix(new string[] {"flower","flow","flight"}));
            Console.WriteLine(" == {0}", new Solution().LongestCommonPrefix(new string[] {"dog","racecar","car"}));
            Console.WriteLine(" == {0}", new Solution().LongestCommonPrefix(new string[] {}));
            Console.WriteLine("small == {0}", new Solution().LongestCommonPrefix(new string[] { "small" }));
            Console.WriteLine(" == {0}", new Solution().LongestCommonPrefix(new string[] { "", "b" }));
            Console.WriteLine(" == {0}", new Solution().LongestCommonPrefix(new string[] { "b", "" }));
            Console.WriteLine("a == {0}", new Solution().LongestCommonPrefix(new string[] { "a", "ac" }));
            Console.WriteLine(" == {0}", new Solution().LongestCommonPrefix(new string[] { "caa","","a","acb" }));
        }
    }
}

public class Solution {
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 1 || (strs.Length > 1 && string.IsNullOrEmpty(strs[0])))
        {
            return strs[0];
        }
        
        var prefix = string.Empty;
        var prevPrefix = string.Empty;
        
        var smallestString = GetSmallestString(strs);
        
        for (var i = 0; i < smallestString; i++)
        {
            if (i > strs[0].Length - 1)
            {
                return prevPrefix;
            }
            
            prefix += strs[0][i];

            for (int j = 1; j < strs.Length; j++)
            {
                var currentString = strs[j];
                if (i > currentString.Length - 1)
                {
                    return prevPrefix;
                }
                
                var currentPrefix = currentString.Substring(0, i + 1);
                
                if (currentPrefix != prefix)
                {
                    return prevPrefix;
                }
            }

            prevPrefix = prefix;
        }

        return prefix;
    }

    private int GetSmallestString(string[] strs)
    {
        var result = 0;

        for (int i = 0; i < strs.Length; i++)
        {
            var length = strs[i].Length; 
            if (result == 0)
            {
                result = length;
            }
            else
            {
                if (result > length)
                {
                    result = length;
                }                
            }
        }

        return result;
    }
}