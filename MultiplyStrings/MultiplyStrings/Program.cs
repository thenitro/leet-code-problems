using System;
using System.Text;

namespace MultiplyStrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("6" == new Solution().Multiply("2", "3"));
            Console.WriteLine("56088" == new Solution().Multiply("123", "456"));
        }
    }
}

public class Solution {
    public string Multiply(string num1, string num2)
    {
        var m = num1.Length;
        var n = num2.Length;

        var pos = new int[m + n];

        for (var i = m - 1; i >= 0; i--)
        {
            for (var j = n - 1; j >= 0; j--)
            {
                var mul = (num1[i] - '0') * (num2[j] - '0');
                
                var p1 = i + j;
                var p2 = i + j + 1;
                
                var sum = mul + pos[p2];

                pos[p1] += sum / 10;
                pos[p2] = sum % 10;
            }
        }

        var sb = new StringBuilder();

        foreach (var i in pos)
        {
            if (!(sb.Length == 0 && i == 0))
            {
                sb.Append(i);
            }
        }
        
        return sb.Length == 0 ? "0" : sb.ToString();
    }
}