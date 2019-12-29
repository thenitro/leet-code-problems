using System;

namespace CountingBits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().CountBits(2)));
            Console.WriteLine(string.Join(",", new Solution().CountBits(5)));
        }
    }
}

public class Solution
{
    public int[] CountBits(int num)
    {
        var result = new int[num + 1];
        
        for (var i = 0; i <= num; i++)
        {
            result[i] = PopCount(i);
        }

        return result;
    }

    private int PopCount(int x)
    {
        var result = 0;

        while (x != 0)
        {
            x &= x - 1;
            result++;
        }
        
        return result;
    }
}