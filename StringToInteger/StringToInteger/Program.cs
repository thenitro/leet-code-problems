using System;
using System.Configuration;

namespace StringToInteger
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().MyAtoi("42"));
            Console.WriteLine(new Solution().MyAtoi("   -42"));
            Console.WriteLine(new Solution().MyAtoi("4193 with words"));
            Console.WriteLine(new Solution().MyAtoi("words and 987"));
            Console.WriteLine(new Solution().MyAtoi("-91283472332"));
            Console.WriteLine(new Solution().MyAtoi(""));
            Console.WriteLine(new Solution().MyAtoi("-"));
            Console.WriteLine(new Solution().MyAtoi("1"));
            Console.WriteLine(new Solution().MyAtoi("-1"));
            Console.WriteLine(new Solution().MyAtoi("+1"));
            Console.WriteLine(new Solution().MyAtoi("  0000000000012345678"));
            Console.WriteLine(new Solution().MyAtoi("010"));
            Console.WriteLine(new Solution().MyAtoi("   +0 123"));
            Console.WriteLine(new Solution().MyAtoi("2147483648"));
            Console.WriteLine(new Solution().MyAtoi("-2147483648"));
            Console.WriteLine(new Solution().MyAtoi("-2147483649"));
            Console.WriteLine(new Solution().MyAtoi("-6147483648"));
        }
    }
}

public class Solution {
    public int MyAtoi(string str) {
        if (string.IsNullOrEmpty(str)) { return 0; }
        
        int res = 0, i = 0, sign = 1;
        
        while (i < str.Length && Char.IsWhiteSpace(str[i])) { i++; }
        
        if (i < str.Length && (str[i] == '-' || str[i] == '+')) {
            sign = str[i++] == '-' ? -1 : 1;
        }
        
        while (i < str.Length && Char.IsDigit(str[i])) {
            int dig = str[i++] - '0';
            int threshold = (int.MaxValue - dig) / 10;
            
            if (res > threshold) {
                return sign == -1 ? int.MinValue : int.MaxValue;
            }
            
            res = res * 10 + dig;
        }
        
        return res * sign;
    }
}