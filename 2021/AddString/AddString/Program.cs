using System;
using System.Text;

namespace AddString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("100" == new Solution().AddStrings("99", "1"));
            Console.WriteLine("134" == new Solution().AddStrings("11", "123"));
            Console.WriteLine("533" == new Solution().AddStrings("456", "77"));
            Console.WriteLine("0" == new Solution().AddStrings("0", "0"));
        }
    }
}

public class Solution
{
    public string AddStrings(string num1, string num2)
    {
        var result = string.Empty;
        
        var count = 1;
        var carry = 0;

        while (count <= num1.Length || count <= num2.Length)
        {
            var symbol1 = GetSymbol(num1, count);
            var symbol2 = GetSymbol(num2, count);

            var sum = symbol1 + symbol2 + carry;
            carry = 0;
            
            if (sum >= 10)
            {
                sum -= 10;
                carry = 1;
            }

            count++;

            result = sum + result;
        }

        if (carry != 0)
        {
            result = "1" + result;
        }

        return result;
    }

    private int GetSymbol(string num, int offset)
    {
        if (num.Length < offset)
        {
            return 0;
        }

        return num[num.Length - offset] - '0';
    }
}