using System;
using System.Collections.Generic;

namespace WordPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().WordPattern("abba", "dog cat cat dog"));
            Console.WriteLine(false == new Solution().WordPattern("abba", "dog cat cat fish"));
            Console.WriteLine(false == new Solution().WordPattern("aaaa", "dog cat cat dog"));
            Console.WriteLine(false == new Solution().WordPattern("abba", "dog dog dog dog"));
        }
    }
}

public class Solution {
    public bool WordPattern(string pattern, string str)
    {
        var patternSplit = pattern.ToCharArray();
        var strSplit = str.Split(' ');

        if (patternSplit.Length != strSplit.Length)
        {
            return false;
        }

        var patternToStr = new Dictionary<char, string>();
        var strToPattern = new Dictionary<string, char>();

        for (var i = 0; i < patternSplit.Length; i++)
        {
            var patternKey = patternSplit[i];
            var strKey = strSplit[i];
            
            if (patternToStr.ContainsKey(patternKey) && strToPattern.ContainsKey(strKey))
            {
                var expectedStr = patternToStr[patternKey];
                var expectedPattern = strToPattern[strKey];
                
                if (strKey != expectedStr || patternKey != expectedPattern)
                {
                    return false;
                }
            } 
            else if (!patternToStr.ContainsKey(patternKey) && !strToPattern.ContainsKey(strKey))
            {
                patternToStr[patternKey] = strKey;
                strToPattern[strKey] = patternKey;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}