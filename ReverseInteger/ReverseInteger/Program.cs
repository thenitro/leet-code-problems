using System;
using System.Linq;

namespace ReverseInteger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("123, 321 {0}", 321 == new Solution().Reverse(123));
            Console.WriteLine("-123, -321 {0}", -321 == new Solution().Reverse(-123));
            Console.WriteLine("120, 21 {0}", 21 == new Solution().Reverse(120));
        }
    }
}

public class Solution
{
    public int Reverse(int x)
    {
        var str = x.ToString();
        var isNegative = 1;

        if (str.StartsWith("-"))
        {
            str = str.Substring(1, str.Length - 1);
            isNegative = -1;
        }
        
        var arr = str.ToArray().Reverse().ToArray();

        var resultStr = string.Join("", arr);
        int result;

        var success = Int32.TryParse(resultStr, out result);
        if (success)
        {
            return result * isNegative;
        }

        return 0;
    }    
}