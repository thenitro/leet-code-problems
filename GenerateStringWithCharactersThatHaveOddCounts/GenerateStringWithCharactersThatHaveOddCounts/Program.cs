using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GenerateStringWithCharactersThatHaveOddCounts
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().GenerateTheString(4));
            Console.WriteLine(new Solution().GenerateTheString(2));
            Console.WriteLine(new Solution().GenerateTheString(7));
            Console.WriteLine(new Solution().GenerateTheString(52));
            Console.WriteLine(new Solution().GenerateTheString(74));
        }
    }
}

public class Solution
{
    private Random _random = new Random();
    
    public string GenerateTheString(int n)
    {
        return Helper(n, new HashSet<char>());
    }

    private string Helper(int n, HashSet<char> taken)
    {   
        if (n % 2 == 0)
        {
            return GenerateRandomStringOfSize(1, taken) + Helper(n - 1, taken);
        }

        return GenerateRandomStringOfSize(n, taken);
    }

    private string GenerateRandomStringOfSize(int n, HashSet<char> taken)
    {
        var c = GetRandomChar(taken);
        var sb = new StringBuilder();
        
        for (var i = 0; i < n; i++)
        {
            sb.Append(c);
        }

        return sb.ToString();
    }

    private char GetRandomChar(HashSet<char> taken)
    {
        var random = _random.Next(97, 97 + 26);
        var c = (char) random;

        while (taken.Contains(c))
        {
            random = _random.Next(97, 97 + 26);
            c = (char) random;
        }

        taken.Add(c);

        return c;
    }
}