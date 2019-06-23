using System;

namespace AddDigits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().AddDigits(38));
        }
    }
}

public class Solution {
    public int AddDigits(int num)
    {
        var s = num.ToString();
        var sum = int.Parse(s);

        while (s.Length > 1)
        {
            sum = 0;

            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                sum += c - '0';
            }

            s = sum.ToString();
        }

        return sum;
    }
}