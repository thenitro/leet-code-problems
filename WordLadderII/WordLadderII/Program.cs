using System;
using System.Collections.Generic;

namespace WordLadderII
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().FindLadders("hit", "cog", new List<string>() { "hot", "got", "dog", "lot", "log", "cog"});

            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                
                Console.WriteLine();
            }
            
            result = new Solution().FindLadders("hit", "cog", new List<string>() { "hot", "got", "dog", "lot", "log"});

            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                
                Console.WriteLine();
            }
        }
    }
}

public class Solution {
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        var dict = new HashSet<string>(wordList);
        var results = new List<IList<string>>();

        var nodeNeighbors = new Dictionary<string, List<string>>();
        var distance = new Dictionary<string, int>();
        var solution = new List<string>();

        dict.Add(beginWord);
        Bfs(beginWord, endWord, dict, nodeNeighbors, distance);
        Dfs(beginWord, endWord, dict, nodeNeighbors, distance, solution, results);
        
        return results;
    }

    private void Bfs(string start, string end, HashSet<string> dict, Dictionary<string, List<string>> nodeNeighbors,
        Dictionary<string, int> distance)
    {
        foreach (var str in dict)
        {
            nodeNeighbors.Add(str, new List<string>());
        }
        
        var queue = new Queue<string>();
            queue.Enqueue(start);
            distance.Add(start, 0);

        while (queue.Count > 0)
        {
            var count = queue.Count;
            var isFoundEnd = false;

            for (int i = 0; i < count; i++)
            {
                var current = queue.Dequeue();
                var currentDistance = distance[current];

                var neighbors = GetNeighbors(current, dict);

                foreach (var neighbor in neighbors)
                {
                    nodeNeighbors[current].Add(neighbor);

                    if (!distance.ContainsKey(neighbor))
                    {
                        distance.Add(neighbor, currentDistance + 1);

                        if (end.Equals(neighbor))
                        {
                            isFoundEnd = true;
                        }
                        else
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }

                if (isFoundEnd)
                {
                    break;
                }
            }
        }
    }

    private List<string> GetNeighbors(string node, HashSet<string> dict)
    {
        var result = new List<string>();
        var chars = node.ToCharArray();

        for (var ch = 'a'; ch <= 'z'; ch++)
        {
            for (var i = 0; i < chars.Length; i++)
            {
                if (chars[i] == ch) continue;
                var oldChar = chars[i];
                chars[i] = ch;

                var str = new string(chars);
                
                if (dict.Contains(str))
                {
                    result.Add(str);
                }

                chars[i] = oldChar;
            }
        }

        return result;
    }

    private void Dfs(string current, string end, HashSet<string> dict, Dictionary<string, List<string>> nodeNeighbors,
        Dictionary<string, int> distance, List<string> solution, List<IList<string>> results)
    {
        solution.Add(current);

        if (end.Equals(current))
        {
            results.Add(new List<string>(solution));
        }
        else
        {
            foreach (var next in nodeNeighbors[current])
            {
                if (distance[next] == distance[current] + 1)
                {
                    Dfs(next, end, dict, nodeNeighbors, distance, solution, results);
                }
            }
        }

        solution.RemoveAt(solution.Count - 1);
    }
}