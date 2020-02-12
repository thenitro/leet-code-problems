using System;
using System.Collections.Generic;

namespace JewelsAndStones
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().NumJewelsInStones("aA", "aAAbbbb"));
            Console.WriteLine(0 == new Solution().NumJewelsInStones("z", "ZZ"));
        }
    }
}

public class Solution
{
    public int NumJewelsInStones(string J, string S)
    {
        var dictionary = new Dictionary<char, int>();

        for (var i = 0; i < S.Length; i++)
        {
            var character = S[i];
            
            dictionary[character] = dictionary.ContainsKey(character) ? dictionary[character] + 1 : 1;
        }

        var result = 0;

        for (var i = 0; i < J.Length; i++)
        {
            var character = J[i];

            if (dictionary.ContainsKey(character))
            {
                result += dictionary[character];
            }
        }

        return result;
    }
}