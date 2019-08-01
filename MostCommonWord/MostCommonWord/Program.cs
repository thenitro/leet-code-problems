using System;
using System.Collections.Generic;
using System.Text;

namespace MostCommonWord
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ball" == new Solution().MostCommonWord("Bob hit a ball, the hit BALL flew far after it was hit.", new []{ "hit" }));
            Console.WriteLine("b" == new Solution().MostCommonWord("a, a, a, a, b,b,b,c, c", new []{ "a" }));
        }
    }
}

public class Solution {
    public string MostCommonWord(string paragraph, string[] banned)
    {
        var bannedSet = new HashSet<string>();

        foreach (var str in banned)
        {
            bannedSet.Add(str);
        }

        paragraph = paragraph.ToLower();
        
        var sb = new StringBuilder();

        foreach (var c in paragraph)
        {
            if (char.IsPunctuation(c))
            {
                sb.Append(' ');
            }
            else
            {
                sb.Append(c);
            }
        }

        var arr = sb.ToString().Split(' ');
        var counter = new Dictionary<string, int>();

        foreach (var s in arr)
        {
            if (bannedSet.Contains(s) || string.IsNullOrWhiteSpace(s))
            {
                continue;
            }
            
            counter[s] = counter.ContainsKey(s) ? counter[s] + 1 : 1;
        }

        var result = string.Empty;
        var max = int.MinValue;

        foreach (var kv in counter)
        {
            if (kv.Value > max)
            {
                result = kv.Key;
                max = kv.Value;
            }
        }
        
        return result;
    }
}