using System;
using System.Collections.Generic;

namespace KthSmallestElementInASortedMatrix
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(13 == new Solution().KthSmallest(new int[][]
            {
                new int[] {1, 5, 9}, 
                new int[] {10, 11, 13}, 
                new int[] {12, 13, 15}, 
            }, 8));
        }
    }
}

public class Solution {
    public int KthSmallest(int[][] matrix, int k)
    {
        var list = new List<int>();

        foreach (var i in matrix)
        {
            foreach (var j in i)
            {
                list.Add(j);
            }
        }
        
        list.Sort();

        return list[k - 1];
    }
}