using System;
using System.Collections.Generic;
using System.Text;

namespace DecodeString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("aaabcbc" == new Solution().DecodeString("3[a]2[bc]"));
            Console.WriteLine("accaccacc" == new Solution().DecodeString("3[a2[c]]"));
            Console.WriteLine("abcabccdcdcdef" == new Solution().DecodeString("2[abc]3[cd]ef"));
        }
    }
}

public class Solution
{
    public string DecodeString(string s)
    {
        var counters = new Stack<int>();
        var subresult = new Stack<string>();
        var result = string.Empty;
        var index = 0;

        while (index < s.Length)
        {
            if (Char.IsDigit(s[index]))
            {
                var resultDigit = 0;

                while (Char.IsDigit(s[index]))
                {
                    resultDigit = resultDigit * 10 + s[index] - '0';
                    index += 1;
                }
                
                counters.Push(resultDigit);
            } 
            else if (s[index] == '[')
            {
                subresult.Push(result);
                index += 1;
                result = string.Empty;
            }
            else if (s[index] == ']')
            {
                var count = counters.Pop();
                var tmp = subresult.Pop();

                for (var i = 0; i < count; i++)
                {
                    tmp += result;
                }

                result = tmp;
                index += 1;
            }
            else
            {
                result += s[index];
                index += 1;
            }
        }
        
        return result;
    }
}