using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace TopKFrequentWords
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().TopKFrequent(new string[] { "i", "love", "leetcode", "i", "love", "coding"}, 2);
            Console.WriteLine(string.Join(", ", result));
            
            var result2 = new Solution().TopKFrequent(new string[] { "the", "day", "is", "sunny", "the", "the", "sunny", "is", "is"}, 4);
            Console.WriteLine(string.Join(", ", result2));
        }
    }
}

public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        var dict = new Dictionary<string, int>();

        foreach (var word in words)
        {
            dict[word] = dict.ContainsKey(word) ? dict[word] + 1 : 1;
        }
        
        var kvs = new List<KeyValuePair<string, int>>();
        foreach (var kv in dict)
        {
            kvs.Add(kv);
        }
        
        kvs.Sort((x,y) => x.Value == y.Value ? String.Compare(x.Key, y.Key, StringComparison.Ordinal) : y.Value.CompareTo(x.Value));

        var result = new List<string>();
        var count = 0;
        
        foreach (var kv in kvs)
        {
            result.Add(kv.Key);
            count++;

            if (count == k)
            {
                break;
            }
        }

        return result;
    }
}