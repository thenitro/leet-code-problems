using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace LetterCombinationsOfAPhoneNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().LetterCombinations("23");

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
            
            result = new Solution().LetterCombinations("3");

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
            
            result = new Solution().LetterCombinations("72");

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
            
            result = new Solution().LetterCombinations("39");

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
        }
    }
}

public class Solution
{
    private readonly List<List<string>> Map = new List<List<string>>()
    {
        new List<string>()
        {
            "a", "b", "c",
        },
        new List<string>()
        {
            "d", "e", "f",
        },
        new List<string>()
        {
            "g", "h", "i",
        },
        new List<string>()
        {
            "j", "k", "l",
        },
        new List<string>()
        {
            "m", "n", "o",
        },
        new List<string>()
        {
            "p", "q", "r", "s"
        },
        new List<string>()
        {
            "t", "u", "v"
        },
        new List<string>()
        {
            "w", "x", "y", "z"
        },
    };
    
    public IList<string> LetterCombinations(string digits) {
        if (digits.Length == 0)
        {
            return new List<string>();
        }
        
        var result = new List<string>();

        AddNumber(digits, 0, result, string.Empty);
        
        return result;
    }

    private void AddNumber(string digits, int i, List<string> result, string subresult)
    {
        if (i == digits.Length)
        {
            result.Add(subresult);
            return;
        }

        var digit = Map[ConvertToIndex(digits[i])];

        foreach (var characted in digit)
        {
            AddNumber(digits, i + 1, result, subresult + characted);
        }
    }

    private int ConvertToIndex(char c)
    {
        return (c - '0') - 2;
    }
}