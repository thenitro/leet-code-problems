using System;
using System.Collections.Generic;
using System.Text;

namespace WordBreak2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",",
                new Solution().WordBreak("catsanddog", new List<string>() {"cat", "cats", "and", "sand", "dog"})));
        }
    }

    public class Solution
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var result = new List<string>();
            Helper(s, wordDict, string.Empty, result);
            return result;
        }

        private void Helper(string s, IList<string> dict, string currentResult, List<string> result)
        {
            if (s.Length == 0)
            {
                result.Add(currentResult);
                return;
            }

            foreach (var word in dict)
            {
                if (s.StartsWith(word))
                {
                    Helper(s.Substring(word.Length), dict, string.IsNullOrEmpty(currentResult) ? word : currentResult + " " + word, result);
                }
            }
        }
    }
}