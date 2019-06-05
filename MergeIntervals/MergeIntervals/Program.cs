using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MergeIntervals
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().Merge(new int[][] { new int[] {1,3}, new int[] {2,6},new int[] {8,10},new int[] {15,18} });

            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");                    
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine("-----");
            
            result = new Solution().Merge(new int[][] { new int[] {1,4}, new int[] {4,5} });
            
            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");                    
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine("-----");
            
            result = new Solution().Merge(new int[][] { new int[] {1,4} });
            
            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");                    
                }
                
                Console.WriteLine();
            }
            
            new Solution().Merge(new int[][] {});
            new Solution().Merge(null);
            
            Console.WriteLine("-----");
            
            result = new Solution().Merge(new int[][] { new int[] {1,4}, new int[] { 0, 4} });
            
            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");                    
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine("-----");
            
            result = new Solution().Merge(new int[][] { new int[] {1,4}, new int[] { 0, 1} });
            
            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");                    
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine("-----");
            
            result = new Solution().Merge(new int[][] { new int[] {1,4}, new int[] { 0, 0} });
            
            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");                    
                }
                
                Console.WriteLine();
            }
        }
    }
}

public class Solution
{
    private class IntervalComparer : Comparer<int[]>
    {
        public override int Compare(int[] x, int[] y)
        {
            return x[0] < y[0] ? -1 : x[0] == y[0] ? 0 : 1;
        }
    }

    public int[][] Merge(int[][] intervals)
    {
        if (intervals == null)
        {
            return null;
        }
        
        Array.Sort(intervals, new IntervalComparer());
        
        var result = new LinkedList<int[]>();

        foreach (var interval in intervals)
        {
            if (result.Count == 0 || result.Last.Value[1] < interval[0])
            {
                result.AddLast(interval);
            }
            else
            {
                result.Last.Value[1] = Math.Max(result.Last.Value[1], interval[1]);
            }
        }

        return result.ToArray();
    }
}