using System;
using System.Collections.Generic;

namespace RansomNote
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(false == new Solution().CanConstruct("a", "b"));
            Console.WriteLine(false == new Solution().CanConstruct("aa", "ab"));
            Console.WriteLine(true == new Solution().CanConstruct("aa", "aab"));
            Console.WriteLine(true == new Solution().CanConstruct("aa", "baab"));
            Console.WriteLine(true == new Solution().CanConstruct("bjaajgea",
                                  "affhiiicabhbdchbidghccijjbfjfhjeddgggbajhidhjchiedhdibgeaecffbbbefiabjdhggihccec"));
        }
    }
}

public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var dictionary = new Dictionary<char, int>();

        foreach (var c in magazine)
        {
            dictionary[c] = dictionary.ContainsKey(c) ? dictionary[c] + 1 : 1;
        }

        foreach (var c in ransomNote)
        {
            if (!dictionary.ContainsKey(c) || dictionary[c] < 1)
            {
                return false;
            }

            dictionary[c] = dictionary[c] - 1;
        }

        return true;
    }
}