using System;

namespace LengthOfLastWord
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(5 == new Solution().LengthOfLastWord("Hello world"));
            Console.WriteLine(0 == new Solution().LengthOfLastWord(""));
            Console.WriteLine(0 == new Solution().LengthOfLastWord(" "));
            Console.WriteLine(5 == new Solution().LengthOfLastWord("Hello "));
            Console.WriteLine(5 == new Solution().LengthOfLastWord(" world"));
            Console.WriteLine(1 == new Solution().LengthOfLastWord("a"));
            Console.WriteLine(1 == new Solution().LengthOfLastWord("a "));
            Console.WriteLine(1 == new Solution().LengthOfLastWord("b a "));
        }
    }
}

public class Solution {
    public int LengthOfLastWord(string s)
    {
        var result = 0;

        if (s.Length > 0)
        {
            var skippedWhiteSpaces = s[s.Length - 1] != ' ';

            for (var i = s.Length; i > 0; i--)
            {
                var isWhiteSpace = s[i - 1] == ' ';

                if (isWhiteSpace)
                {
                    if (!skippedWhiteSpaces)
                    {
                        continue;
                    }

                    break;
                }
                
                skippedWhiteSpaces = true;
                result++;
            }
        }
        
        return result;
    }
}