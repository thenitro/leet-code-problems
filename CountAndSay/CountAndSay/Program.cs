using System;

namespace CountAndSay
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1" == new Solution().CountAndSay(1));
            Console.WriteLine("1211" == new Solution().CountAndSay(4));
        }
    }
}

public class Solution {
    public string CountAndSay(int n)
    {
        var result = "1";

        for (var i = 1; i < n; i++)
        {
            var tmp = string.Empty;
            var count = 1;

            for (var j = 1; j < result.Length; j++)
            {
                if (result[j - 1] == result[j])
                {
                    count += 1;
                }
                else
                {
                    tmp += count.ToString() + result[j - 1];
                    count = 1;
                }
            }

            result = tmp + count.ToString() + result[result.Length - 1];
        }

        return result;
    }
}