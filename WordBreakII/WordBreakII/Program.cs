using System;
using System.Collections.Generic;

namespace WordBreakII
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().WordBreak("catsanddog", new string[] { "cat", "cats", "and", "sand", "dog" });

            foreach (var r in result)
            {
                Console.WriteLine(r + " ");
            }
            
            Console.WriteLine();
            
            result = new Solution().WordBreak("pineapplepenapple", new string[] { "apple", "pen", "applepen", "pine", "pineapple" });
            
            foreach (var r in result)
            {
                Console.WriteLine(r + " ");
            }
            
            Console.WriteLine();
            
            result = new Solution().WordBreak("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" });
            
            foreach (var r in result)
            {
                Console.WriteLine(r + " ");
            }
            
            Console.WriteLine();
        }
    }
}

public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        return Dfs(s, wordDict, new Dictionary<string, List<string>>());
    }

    private List<string> Dfs(string s, IList<string> wordDict, Dictionary<string, List<string>> map)
    {
        if (map.ContainsKey(s))
        {
            return map[s];
        }
        
        var result = new List<string>();
        if (s.Length == 0)
        {
            result.Add(string.Empty);
            return result;
        }

        foreach (var word in wordDict)
        {
            if (s.StartsWith(word))
            {
                var sublist = Dfs(s.Substring(word.Length), wordDict, map);
                foreach (var sub in sublist)
                {
                    result.Add(word + (string.IsNullOrEmpty(sub) ? "" : " ") + sub);
                }
            }
        }

        map[s] = result;
        
        return result;
    }
}