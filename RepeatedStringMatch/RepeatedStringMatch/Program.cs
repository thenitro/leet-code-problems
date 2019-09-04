using System;
using System.Text;

namespace RepeatedStringMatch
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().RepeatedStringMatch("a", "aa"));
            Console.WriteLine(3 == new Solution().RepeatedStringMatch("abcd", "cdabcdab"));
        }
    }
}

public class Solution
{
    public int RepeatedStringMatch(string A, string B)
    {
        var result = 1;

        var sb = new StringBuilder(A);
        while (sb.Length < B.Length)
        {
            sb.Append(A);
            result++;
        }

        if (sb.ToString().Contains(B)) return result;
        if (sb.Append(A).ToString().Contains(B)) return result + 1;

        return -1;
    }
}