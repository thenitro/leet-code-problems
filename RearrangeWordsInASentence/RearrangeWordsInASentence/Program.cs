using System;
using System.Linq;

namespace RearrangeWordsInASentence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Is cool leetcode" == new Solution().ArrangeWords("Leetcode is cool"));
            Console.WriteLine("On and keep calm code" == new Solution().ArrangeWords("Keep calm and code on"));
            Console.WriteLine("To be or to be not" == new Solution().ArrangeWords("To be or not to be"));
            Console.WriteLine("I you and" == new Solution().ArrangeWords("You and i"));
        }
    }
}

public class Solution
{
    public string ArrangeWords(string text)
    {
        var query = text.ToLower().Split(" ").OrderBy(s => s.Length);
        var words = query.ToArray();
        
        var first = words[0];
        words[0] = first.First().ToString().ToUpper() + first.Substring(1);
        
        return string.Join(" ", words);
    }
}