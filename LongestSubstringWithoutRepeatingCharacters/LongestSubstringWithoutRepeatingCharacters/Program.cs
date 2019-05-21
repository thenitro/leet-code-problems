using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LongestSubstringWithoutRepeatingCharacters
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("abcabcbb 3 {0}", new Solution().LengthOfLongestSubstring("abcabcbb"));
            Console.WriteLine("bbbbb 1 {0}", new Solution().LengthOfLongestSubstring("bbbbb"));
            Console.WriteLine("pwwkew 3 {0}", new Solution().LengthOfLongestSubstring("pwwkew"));
            Console.WriteLine(" 1 {0}", new Solution().LengthOfLongestSubstring(" "));
            Console.WriteLine("0 {0}", new Solution().LengthOfLongestSubstring(""));
            Console.WriteLine("aa 1 {0}", new Solution().LengthOfLongestSubstring("aa"));
            Console.WriteLine("au 2 {0}", new Solution().LengthOfLongestSubstring("au"));
            Console.WriteLine("aab 2 {0}", new Solution().LengthOfLongestSubstring("aab"));
        }
    }
}

public class Solution {
    public int LengthOfLongestSubstring(string s)
    {
        var set = new HashSet<char>();

        var longest = 0;
        var startWith = 0;
        var counter = 0;
        
        for (var i = 0; i < s.Length; i++)
        {
            if (set.Contains(s[i]))
            {
                set.Clear();
                
                i = startWith;
                startWith++;
                counter = 0;
            }
            else
            {
                set.Add(s[i]);

                counter++;
                
                if (counter > longest)
                {
                    longest = counter;
                }                
            }
        }

        return longest;
    }
}