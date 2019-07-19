using System;
using System.Collections.Generic;
using System.Text;

namespace ReconstructOriginalDigitsFromEnglish
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("012" == new Solution().OriginalDigits("owoztneoer"));
            Console.WriteLine("45" == new Solution().OriginalDigits("fviefuro"));
        }
    }
}

public class Solution {
    public string OriginalDigits(string s)
    {
        var count = new int[10];

        foreach (var c in s)
        {
            if (c == 'z') count[0]++;
            if (c == 'w') count[2]++;
            if (c == 'x') count[6]++;
            if (c == 's') count[7]++;
            if (c == 'g') count[8]++;
            if (c == 'u') count[4]++;
            if (c == 'f') count[5]++;
            if (c == 'h') count[3]++;
            if (c == 'i') count[9]++;
            if (c == 'o') count[1]++;
        }

        count[7] -= count[6];
        count[5] -= count[4];
        count[3] -= count[8];
        count[9] = count[9] - count[8] - count[5] - count[6];
        count[1] = count[1] - count[0] - count[2] - count[4];

        var sb = new StringBuilder();

        for (var i = 0; i <= 9; i++)
        {
            for (var j = 0; j < count[i]; j++)
            {
                sb.Append(i);
            }
        }

        return sb.ToString();
    }
}