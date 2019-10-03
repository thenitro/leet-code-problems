using System;

namespace DetectCapital
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().DetectCapitalUse("USA"));
            Console.WriteLine(true == new Solution().DetectCapitalUse("leetcode"));
            Console.WriteLine(true == new Solution().DetectCapitalUse("Google"));
            Console.WriteLine(false == new Solution().DetectCapitalUse("FlaG"));
        }
    }
}

public class Solution
{
    public bool DetectCapitalUse(string word)
    {
        var amountOfCapitals = CalculateCapitalsAmount(word);
        
        return (FirstLetterIsCapital(word) && amountOfCapitals == 1) || amountOfCapitals == 0 || amountOfCapitals == word.Length;
    }

    private int CalculateCapitalsAmount(string word)
    {
        var count = 0;
        
        foreach (var character in word)
        {
            if (Char.IsUpper(character))
            {
                count++;
            }
        }

        return count;
    }

    private bool FirstLetterIsCapital(string word)
    {
        return Char.IsUpper(word[0]);
    }
}