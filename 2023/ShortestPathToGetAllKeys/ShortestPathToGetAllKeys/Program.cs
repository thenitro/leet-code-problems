using System;

namespace ShortestPathToGetAllKeys
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(8 == new Solution().ShortestPathAllKeys(new[] { "@.a..", "###.#", "b.A.B" }));
        }
    }
}