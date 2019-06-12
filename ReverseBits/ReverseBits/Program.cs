using System;

namespace ReverseBits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(964176192 == new Solution().reverseBits(43261596));
            Console.WriteLine(3221225471 == new Solution().reverseBits(4294967293));
        }
    }
}

public class Solution {
    public uint reverseBits(uint n) {
        if (n == 0)
        {
            return 0;
        }

        uint result = 0;
        for (var i = 0; i < 32; i++)
        {
            result <<= 1;
            if ((n & 1) == 1) result++;

            n >>= 1;
        }

        return result;
    }
}