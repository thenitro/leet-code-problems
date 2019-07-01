using System;
using System.Collections.Generic;

namespace NimGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(false == new Solution().CanWinNim(4));
            Console.WriteLine(true == new Solution().CanWinNim(5));
            Console.WriteLine(false == new Solution().CanWinNim(1348820612));
        }
    }
}

public class Solution {
    public bool CanWinNim(int n)
    {
        return n % 4 != 0;
    }
}