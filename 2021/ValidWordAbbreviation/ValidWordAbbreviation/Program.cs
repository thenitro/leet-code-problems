using System;

namespace ValidWordAbbreviation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().ValidWordAbbreviation("internationalization", "i12iz4n"));
            Console.WriteLine(false == new Solution().ValidWordAbbreviation("apple", "a2e"));
            Console.WriteLine(new Solution().ValidWordAbbreviation("internationalization", "i5a11o1"));
        }
    }
}

public class Solution
{
    public bool ValidWordAbbreviation(string word, string abbr)
    {
        var wordIndex = 0;
        var abbrIndex = 0;

        while (wordIndex < word.Length && abbrIndex < abbr.Length)
        {
            if (char.IsDigit(abbr[abbrIndex]))
            {
                if (abbr[abbrIndex] == '0')
                {
                    return false;
                }

                var number = 0;

                while (abbrIndex < abbr.Length && char.IsDigit(abbr[abbrIndex]))
                {
                    number = number * 10 + (abbr[abbrIndex] - '0');
                    abbrIndex++;
                }

                wordIndex += number;
            }
            else
            {
                if (word[wordIndex] != abbr[abbrIndex])
                {
                    return false;
                }
                else
                {
                    wordIndex++;
                    abbrIndex++;
                }
            }
        }
        
        return wordIndex == word.Length && abbrIndex == abbr.Length;
    }
}