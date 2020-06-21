using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WordBreak
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().WordBreak("leetcode", new List<string>() { "leet", "code" }));
            Console.WriteLine(true == new Solution().WordBreak("applepenapple", new List<string>() { "apple", "pen" }));
            Console.WriteLine(false == new Solution().WordBreak("catsandog", new List<string>() { "cats", "dog", "sand", "and", "cat" }));
            Console.WriteLine(false == new Solution().WordBreak("ccbb", new List<string>() { "bc", "cb" }));
            Console.WriteLine(true == new Solution().WordBreak("bccdbacdbdacddabbaaaadababadad", new List<string>() { "cbc","bcda","adb","ddca","bad","bbb","dad","dac","ba","aa","bd","abab","bb","dbda","cb","caccc","d","dd","aadb","cc","b","bcc","bcd","cd","cbca","bbd","ddd","dabb","ab","acd","a","bbcc","cdcbd","cada","dbca","ac","abacd","cba","cdb","dbac","aada","cdcda","cdc","dbc","dbcb","bdb","ddbdd","cadaa","ddbc","babb" }));
        }
    }
}

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var dp = new bool[s.Length + 1];
            dp[0] = true;

        for (var i = 1; i <= s.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (dp[j] && wordDict.Contains(s.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[s.Length];
    }
}

public class SolutionSlow
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var memo = new HashSet<string>();
        return Helper(s, wordDict, string.Empty, memo);
    }

    private bool Helper(string target, IList<string> wordDict, string currentString, HashSet<string> memo)
    {
        if (memo.Contains(currentString))
        {
            return false;
        }

        memo.Add(currentString);
        
        if (currentString.Length > target.Length)
        {
            return false;
        }
        
        if (target == currentString)
        {
            return true;
        }

        foreach (var word in wordDict)
        {
            if (Helper(target, wordDict, currentString + word, memo))
            {
                return true;
            }
        }

        return false;
    }
}