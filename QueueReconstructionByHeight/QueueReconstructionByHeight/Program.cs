using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;

namespace QueueReconstructionByHeight
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var queue = new int[][]
            {
                new int[] { 7, 0 },
                new int[] { 4, 4 },
                new int[] { 7, 1 },
                new int[] { 5, 0 },
                new int[] { 6, 1 },
                new int[] { 5, 2 },
            };
            
            var result = new Solution().ReconstructQueue(queue);

            foreach (var subarray in result)
            {
                Console.WriteLine(string.Join(",", subarray));
            }
        }
    }
}

public class Solution
{
    public int[][] ReconstructQueue(int[][] people)
    {
        Array.Sort(people, new PeopleComparer());
        
        var result = new List<int[]>();

        for (var i = 0; i < people.Length; i++)
        {
            result.Add(people[i]);
        }

        foreach (var person in people)
        {
            result.Remove(person);
            result.Insert(person[1], person);
        }

        return result.ToArray();
    }
}

public class PeopleComparer : IComparer<int[]>
{
    public int Compare(int[] x, int[] y)
    {
        return x[0] == y[0] ? x[1] - y[1] : y[0] - x[0];
    }
}