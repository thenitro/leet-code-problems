using System;
using System.Collections.Generic;

namespace VerifyingAlienDictionary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsAlienSorted(new[] {"hello", "leetcode"}, "hlabcdefgijkmnopqrstuvwxyz"));
            Console.WriteLine(false == new Solution().IsAlienSorted(new[] {"word", "world", "row"}, "worldabcefghijkmnpqstuvxyz"));
            Console.WriteLine(false == new Solution().IsAlienSorted(new[] {"apple", "app"}, "abcdefghijklmnopqrstuvwxyz"));
            Console.WriteLine(true == new Solution().IsAlienSorted(new[] {"kuvp", "q"}, "ngxlkthsjuoqcpavbfdermiywz"));
            
        }
    }
}

public class Solution
{
    public bool IsAlienSorted(string[] words, string order)
    {
        var constructedOrder = new Dictionary<char, int>();

        for (var i = 0; i < order.Length; i++)
        {
            constructedOrder[order[i]] = i;
        }

        for (var i = 0; i < words.Length - 1; i++)
        {
            var word1 = words[i];
            var word2 = words[i + 1];

            var length = Math.Min(word1.Length, word2.Length);

            for (var k = 0; k < length; k++)
            {
                if (word1[k] != word2[k])
                {
                    if (constructedOrder[word1[k]] > constructedOrder[word2[k]])
                    {
                        return false;
                    }
                    else
                    {
                        length = -1;
                    }
                }
            }

            if (length != -1 && word1.Length > word2.Length)
            {
                return false;
            }
        }

        return true;
    }
}