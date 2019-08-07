using System;

namespace MirrorReflection
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().MirrorReflection(2, 1));
        }
    }
}

public class Solution
{
    public int MirrorReflection(int p, int q)
    {
        var g = Gcd(p, q);

        p /= g;
        p %= 2;
        
        q /= g;
        q %= 2;

        if (p == 1 && q == 1)
        {
            return 1;
        }

        return p == 1 ? 0 : 2;
    }

    private int Gcd(int a, int b)
    {
        if (a == 0)
        {
            return b;
        }

        return Gcd(b % a, a);
    }
}