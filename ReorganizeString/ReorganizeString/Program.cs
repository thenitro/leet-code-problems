using System;
using System.Collections.Generic;
using System.Text;

namespace ReorganizeString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("aba" == new Solution().ReorganizeString("aab"));
            Console.WriteLine("" == new Solution().ReorganizeString("aaab"));
        }
    }
}

public class Solution
{
    public string ReorganizeString(string S)
    {
        var result = new StringBuilder();
        var dict = new Dictionary<char, int>();

        foreach (var c in S)
        {
            dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
        }

        var list = new List<Tuple<char, int>>();
        
        foreach (var kw in dict)
        {
            list.Add(new Tuple<char, int>(kw.Key, kw.Value));
        }
        
        list.Sort((pairA, pairB) => pairA.Item2.CompareTo(pairB.Item2));

        var index = 0;
        
        while (list.Count > 0)
        {
            result.Append(list[index].Item1);
            list[index] = new Tuple<char, int>(list[index].Item1, list[index].Item2 - 1);

            if (list[index].Item2 <= 0)
            {
                list.RemoveAt(index);
            }

            index++;

            if (index >= list.Count)
            {
                index = 0;
            }
        }

        return result.ToString();
    }
}