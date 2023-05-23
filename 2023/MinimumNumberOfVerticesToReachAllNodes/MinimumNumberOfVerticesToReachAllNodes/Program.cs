using System;
using System.Collections.Generic;

namespace MinimumNumberOfVerticesToReachAllNodes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", new Solution().FindSmallestSetOfVertices(6, new List<IList<int>>()
            {
                new List<int>() { 0, 1 },
                new List<int>() { 0, 2 },
                new List<int>() { 2, 5 },
                new List<int>() { 3, 4 },
                new List<int>() { 4, 2 },
            })));
        }
    }
}