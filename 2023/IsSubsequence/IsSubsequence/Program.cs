using System;

namespace IsSubsequence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsSubsequence("abc", "ahbgdc"));
            Console.WriteLine(new Solution().IsSubsequence("axc", "ahbgdc"));
        }
    }
}