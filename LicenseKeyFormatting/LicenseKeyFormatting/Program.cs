using System;
using System.Linq;
using System.Text;

namespace LicenseKeyFormatting
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("5F3Z-2E9W" == new Solution().LicenseKeyFormatting("5F3Z-2e-9-w", 4));
            Console.WriteLine("2-5G-3J" == new Solution().LicenseKeyFormatting("2-5g-3-J", 2));
        }
    }
}

public class Solution
{
    public string LicenseKeyFormatting(string S, int K)
    {
        const string delimiter = "-";
        var sb = new StringBuilder();

        for (var i = S.Length - 1; i >= 0; i--)
        {
            if (S[i] != '-')
            {
                sb.Append(sb.Length % (K + 1) == K ? delimiter : string.Empty).Append(S[i]);
            }
        }

        return new string(sb.ToString().ToUpper().Reverse().ToArray());
    }
}