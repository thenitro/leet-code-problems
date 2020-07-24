using System;
using System.Collections.Generic;

namespace PrintWordsVertically
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().PrintVertically("HOW ARE YOU")));
            Console.WriteLine("*" + string.Join(",", new Solution().PrintVertically("TO BE OR NOT TO BE")) + "*");
            Console.WriteLine(string.Join(",", new Solution().PrintVertically("CONTEST IS COMING")));
            Console.WriteLine(string.Join(",", new Solution().PrintVertically("AA BBB C DDDD EEEEE F")));
        }
    }
}

public class Solution
{
    public IList<string> PrintVertically(string s)
    {
        var splitted = s.Split(' ');
        var longestWord = GetLongestWord(splitted);

        var result = new string[longestWord];

        for (var j = 0; j < longestWord; j++)
        {
            for (var i = 0; i < splitted.Length; i++)
            {
                if (i == 0)
                {
                    result[j] = "";
                }

                var word = splitted[i];                
                var append = j >= word.Length ? ' ' : word[j];

                result[j] += append;
            }
        }

        for (var j = 0; j < result.Length; j++)
        {
            var word = result[j];
            var splitLength = word.Length;
        
            for (var i = word.Length - 1; i >= 0; i--)
            {
                if (word[i] != ' ')
                {
                    splitLength = i + 1;
                    break;
                }
            }
            
            result[j] = word.Substring(0, splitLength);
        }
        
        return result;
    }

    private int GetLongestWord(string[] splitted)
    {
        var max = int.MinValue;

        foreach (var s in splitted)
        {
            max = Math.Max(s.Length, max);
        }

        return max;
    }
}