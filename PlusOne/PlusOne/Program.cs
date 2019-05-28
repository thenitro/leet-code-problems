using System;
using System.Collections.Generic;

namespace PlusOne
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintArray(new Solution().PlusOne(new int[] { 1, 2, 3 }));
            PrintArray(new Solution().PlusOne(new int[] { 4, 3, 2, 1 }));
            PrintArray(new Solution().PlusOne(new int[] { 1 }));
            PrintArray(new Solution().PlusOne(new int[] { 9 }));
            PrintArray(new Solution().PlusOne(new int[] { 9, 9 }));
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            
            Console.WriteLine();
        }
        
    }
}

public class Solution {
    public int[] PlusOne(int[] digits)
    {
        var length = digits.Length;
        
        var list = new Stack<int>();

        var addOne = false;
        var lastElement = digits[length - 1];
            lastElement++;

        if (lastElement > 9)
        {
            lastElement -= 10;
            addOne = true;
        }
        
        list.Push(lastElement);

        for (var i = length - 2; i >= 0; i--)
        {
            var n = digits[i];
            
            if (addOne)
            {
                n++;
                addOne = false;
            }

            if (n > 9)
            {
                n -= 10;
                addOne = true;
            }
            
            list.Push(n);
        }

        if (addOne)
        {
            list.Push(1);
        }

        return list.ToArray();
    }
}