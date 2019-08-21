using System;

namespace StringCompression
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(6 == new Solution().Compress(new[] {'a', 'a', 'b', 'b', 'c', 'c', 'c'}));
            Console.WriteLine(1 == new Solution().Compress(new[] {'a'}));
            Console.WriteLine(4 == new Solution().Compress(new[] {'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' }));
        }
    }
}

public class Solution
{
    public int Compress(char[] chars)
    {
        var anchor = 0;
        var write = 0;

        for (var read = 0; read < chars.Length; read++)
        {
            if (read + 1 == chars.Length || chars[read + 1] != chars[read])
            {
                chars[write++] = chars[anchor];
                
                if (read > anchor)
                {
                    foreach (var c in (read - anchor + 1).ToString())
                    {
                        chars[write++] = c;
                    }
                }
                
                anchor = read + 1;
            }
        }

        return write;
    }
}