using System;
using System.Linq;

namespace ReverseString2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("bacdfeg" == new Solution().ReverseStr("abcdefg", 2));
            Console.WriteLine("cbadefg" == new Solution().ReverseStr("abcdefg", 3));
            Console.WriteLine("gfedcba" == new Solution().ReverseStr("abcdefg", 8));
            Console.WriteLine("gfedcba" == new Solution().ReverseStr("abcdefg", 1213));
            Console.WriteLine("a" == new Solution().ReverseStr("a", 2));
        }
    }
}

public class Solution
{
    public string ReverseStr(string s, int k)
    {
        var array = s.ToCharArray();
        
        for (var start = 0; start < s.Length; start += 2 * k)
        {
            var i = start;
            var j = Math.Min(start + k - 1, s.Length - 1);

            while (i < j)
            {
                var tmp = array[i];
                array[i++] = array[j];
                array[j--] = tmp;
            }
        }
        
        return new string(array);
    }
}