using System;
using System.Xml;

namespace NumberOfOneBits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(3 == new Solution().HammingWeight(11));
            Console.WriteLine(31 == new Solution().HammingWeight(4294967293));
        }
    }
}

public class Solution {
    public int HammingWeight(uint n)
    {
        var bits = 0;
        var mask = 1;

        for (var i = 0; i < 32; i++)
        {
            if ((n & mask) != 0)
            {
                bits++;
            }

            mask <<= 1;
        }

        return bits;
    }
}