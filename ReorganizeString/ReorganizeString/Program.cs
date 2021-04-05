using System;
using System.Collections.Generic;
using System.Text;

namespace ReorganizeString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("aba" == new Solution().ReorganizeString("aab"));
            Console.WriteLine("" == new Solution().ReorganizeString("aaab"));
            Console.WriteLine("lblflxl" == new Solution().ReorganizeString("blflxll"));
        }
    }
}

public class Solution
{
    public string ReorganizeString(string S)
    {
        var N = S.Length;
        var counts = new int[26];

        foreach (var c in S)
        {
            counts[c - 'a'] += 100;
        }

        for (var i = 0; i < 26; i++)
        {
            counts[i] += i;
        }
        
        Array.Sort(counts);

        var result = new char[N];
        var t = 1;

        foreach (var code in counts)
        {
            var ct = code / 100;
            var ch = (char)('a' + (code % 100));

            if (ct > (N + 1) / 2)
            {
                return string.Empty;
            }

            for (int i = 0; i < ct; i++)
            {
                if (t >= N)
                {
                    t = 0;
                }

                result[t] = ch;
                t += 2;
            }
        }
        
        return new string(result);
    }
}