using System;
using System.Collections.Generic;

namespace PascalsTriangle
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Print2dList(new Solution().Generate(5));
            Console.WriteLine();
            Print2dList(new Solution().Generate(1));
        }

        private static void Print2dList(IList<IList<int>> list)
        {
            foreach (var sublist in list)
            {
                Console.WriteLine(string.Join(",", sublist));
            }
        }
    }
}