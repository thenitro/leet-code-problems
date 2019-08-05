using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().FizzBuzz(15);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}

public class Solution
{
    public IList<string> FizzBuzz(int n)
    {
        var results = new string[n];

        for (int i = 1; i < n + 1; i++)
        {
            var result = string.Empty;

            if (i % 3 == 0 && i % 5 == 0)
            {
                result = "FizzBuzz";
            }
            else if (i % 3 == 0)
            {
                result = "Fizz";
            } 
            else if (i % 5 == 0)
            {
                result = "Buzz";
            }
            else
            {
                result = i.ToString();
            }

            results[i - 1] = result;
        }
        
        return results;
    }
}