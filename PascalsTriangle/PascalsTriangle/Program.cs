using System;
using System.Collections.Generic;

namespace PascalsTriangle
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().Generate(5);

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

public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var result = new List<IList<int>>();
        
        if (numRows == 0)
        {
            return result;
        }
        
        result.Add(new List<int>() { 1 });

        var i = 1;
        while (i < numRows)
        {
            var j = 0;
            var subresult = new List<int>();

            while (j < i + 1)
            {
                var prev = result[i - 1];

                var left = j - 1;
                var right = j;

                var leftValue = 0;
                var rightValue = 0;
                
                if (left >= 0)
                {
                    leftValue = prev[left];
                }

                if (right < prev.Count)
                {
                    rightValue = prev[right];
                }

                var current = leftValue + rightValue;
                
                subresult.Add(current);

                j++;
            }
            
            result.Add(subresult);
            i++;
        }
            
        return result;
    }
}