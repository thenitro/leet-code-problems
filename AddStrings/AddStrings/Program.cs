using System;

namespace AddStrings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("2" == new Solution().AddStrings("1", "1"));
            Console.WriteLine("10" == new Solution().AddStrings("9", "1"));
            Console.WriteLine("11" == new Solution().AddStrings("10", "1"));
            Console.WriteLine("413" == new Solution().AddStrings("408", "5"));
        }
    }
}

public class Solution {
    public string AddStrings(string num1, string num2)
    {
        var result = string.Empty;

        var i = num1.Length - 1;
        var j = num2.Length - 1;

        var carry = 0;
        
        while (i >= 0 || j >= 0)
        {
            var numA = ConvertToInt(num1, i);
            var numB = ConvertToInt(num2, j);
            
            var add = numA + numB + carry;
            
            if (add >= 10)
            {
                carry = 1;
            }
            else
            {
                carry = 0;
            }

            add = add % 10;

            result = add + result;
            
            i--;
            j--;
        }
        
        if (carry == 1)
        {
            result = "1" + result;
        }

        return result;
    }

    private int ConvertToInt(string num, int index)
    {
        if (index < 0)
        {
            return 0;
        }

        var digit = num[index];

        return digit - '0';
    }
}