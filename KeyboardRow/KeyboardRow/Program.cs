using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyboardRow
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().FindWords(new []{ "Hello", "Alaska", "Dad", "Peace" });
            Console.WriteLine(string.Join(",", result));
        }
    }
}

public class Solution
{
    private HashSet<char> Row1 = new HashSet<char>() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'};
    private HashSet<char> Row2 = new HashSet<char>() { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'};
    private HashSet<char> Row3 = new HashSet<char>() { 'z', 'x', 'c', 'v', 'b', 'n', 'm'};
    
    public string[] FindWords(string[] words) 
    {
        var result = new List<string>();
        
        foreach (var word in words)
        {
            var hasFromRow1 = false;
            var hasFromRow2 = false;
            var hasFromRow3 = false;

            foreach (var source in word)
            {
                var symbol = Char.ToLower(source);
                
                if (!hasFromRow1)
                {
                    hasFromRow1 = Row1.Contains(symbol);
                }
                
                if (!hasFromRow2)
                {
                    hasFromRow2 = Row2.Contains(symbol);
                }
                
                if (!hasFromRow3)
                {
                    hasFromRow3 = Row3.Contains(symbol);
                }
            }

            var amountOfRows = 0;
                amountOfRows += hasFromRow1 ? 1 : 0;
                amountOfRows += hasFromRow2 ? 1 : 0;
                amountOfRows += hasFromRow3 ? 1 : 0;

            if (amountOfRows == 1)
            {
                result.Add(word);
            }
        }

        return result.ToArray();
    }
}