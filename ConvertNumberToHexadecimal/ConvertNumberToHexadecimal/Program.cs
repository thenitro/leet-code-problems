using System;

namespace ConvertNumberToHexadecimal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1a" == new Solution().ToHex(26));
            Console.WriteLine("ffffffff" == new Solution().ToHex(-1));
            Console.WriteLine("fffffffe" == new Solution().ToHex(-2));
        }
    }
}

public class Solution
{
    private char[] Map = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};
    
    public string ToHex(int num) {
        if (num == 0)
        {
            return "0";
        }

        var result = string.Empty;
        var count = 0;

        while (num != 0 && count++ < 8)
        {
            result = Map[num & 15] + result;
            num = (num >> 4);
        }

        return result;
    }
}