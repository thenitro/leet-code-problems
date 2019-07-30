using System;
using System.Collections.Generic;

namespace WordLadder
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().LadderLength("hit", "cog",
                                  new List<string>() {"hot", "dot", "dog", "lot", "log", "cog"}));
            Console.WriteLine(0 == new Solution().LadderLength("hit", "cog",
                                  new List<string>() {"hot", "dot", "dog", "lot", "log"}));
        }
    }
}

public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var wordLength = beginWord.Length;
        
        var allCombo = new Dictionary<string, List<string>>();

        foreach (var word in wordList)
        {
            for (var i = 0; i < wordLength; i++)
            {
                var newWord = word.Substring(0, i) + '*' + word.Substring(i + 1, wordLength - (i + 1));
                
                var transformations = allCombo.ContainsKey(newWord) ? allCombo[newWord] : new List<string>();
                    transformations.Add(word);

                allCombo[newWord] = transformations;
            }
        }
        
        var queue = new Queue<Tuple<string, int>>();
            queue.Enqueue(new Tuple<string, int>(beginWord, 1));
            
        var visited = new Dictionary<string, bool>();
            visited[beginWord] = true;

        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            
            var word = item.Item1;
            var level = item.Item2;

            for (var i = 0; i < wordLength; i++)
            {
                var newWord = word.Substring(0, i) + '*' + word.Substring(i + 1, wordLength - (i + 1));
                
                if (!allCombo.ContainsKey(newWord))
                {
                    continue;
                }
                
                foreach (var adjacentWord in allCombo[newWord])
                {
                    if (adjacentWord.Equals(endWord))
                    {
                        return level + 1;
                    }

                    if (!visited.ContainsKey(adjacentWord))
                    {
                        visited[adjacentWord] = true;
                        queue.Enqueue(new Tuple<string, int>(adjacentWord, level + 1));
                    }
                }
            }
        }

        return 0;
    }
}