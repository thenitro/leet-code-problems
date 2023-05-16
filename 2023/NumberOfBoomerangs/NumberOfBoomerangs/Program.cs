using System;

namespace NumberOfBoomerangs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(2 == new Solution().NumberOfBoomerangs(new[] { new[] { 0, 0 }, new[] { 1, 0 }, new[] { 2, 0 } }));
            Console.WriteLine(2 == new Solution().NumberOfBoomerangs(new[] { new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 3 } }));
            Console.WriteLine(0 == new Solution().NumberOfBoomerangs(new[] { new[] { 0, 0 } }));
        }
    }
}