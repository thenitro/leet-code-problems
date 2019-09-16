using System;

namespace NumberComplement
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().FindComplement(5));
            Console.WriteLine(0 == new Solution().FindComplement(1));
        }
    }
}

public class Solution {
    public int FindComplement(int num)
    {
        var str = Convert.ToString(num, 2);
        var val = string.Empty;
        
        for (var i = 0; i < str.Length; i++)
        {
            val += str[i] == '1' ? '0' : '1';
        }
        
        return Convert.ToInt32(val, 2);
    }
}