using System;

namespace SearchA2dMatrix
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().SearchMatrix(new int[][]
            {
                new []{1, 3, 5, 7},
                new []{10, 11, 16, 20},
                new []{23, 30, 34, 50},
            }, 3));
            
            Console.WriteLine(false == new Solution().SearchMatrix(new int[][]
            {
                new []{1, 3, 5, 7},
                new []{10, 11, 16, 20},
                new []{23, 30, 34, 50},
            }, 13));
            
            Console.WriteLine(true == new Solution().SearchMatrix(new int[][]
            {
                new []{1, 3, 5, 7},
                new []{10, 11, 16, 20},
                new []{23, 30, 34, 50},
            }, 11));
            
            Console.WriteLine(false == new Solution().SearchMatrix(new int[][]
            {
            }, 1));
            
            Console.WriteLine(false == new Solution().SearchMatrix(new int[][]
            {
                new int[]{},
            }, 1)); 
            
            Console.WriteLine(true == new Solution().SearchMatrix(new int[][]
            {
                new int[]{ 1, 3},
            }, 3));
            
            Console.WriteLine(false == new Solution().SearchMatrix(new int[][]
            {
                new int[]{ 1, 3, 5},
            }, 2));
        }
    }
}

public class Solution {
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix.Length == 0 || matrix[0].Length == 0)
        {
            return false;
        }
        
        var lo = 0;
        var hi = matrix.Length - 1;
    
        while (lo < hi)
        {
            var middle = (lo + hi) / 2;
            
            var list = matrix[middle];
            
            var firstOfMiddle = list[0];
            var lastOfMiddle = list[list.Length - 1];
            
            if (target == firstOfMiddle || target == lastOfMiddle)
            {
                return true;
            }
            
            if (target > firstOfMiddle && target < lastOfMiddle)
            {
                lo = middle;
                break;
            }
            
            if (target > firstOfMiddle)
            {
                lo = middle + 1;
            }
            else
            {
                hi = middle;
            }
        }

        var currentList = matrix[lo];

        lo = 0;
        hi = currentList.Length;

        while (lo < hi)
        {
            var middleIndex = (lo + hi) / 2;
            var middle = currentList[middleIndex];

            if (middle == target)
            {
                return true;
            }

            if (target > middle)
            {
                lo = middleIndex + 1;
            }
            else
            {
                hi = middleIndex;
            }
        }
        
        return false;
    }
}