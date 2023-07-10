using System;
using System.Collections.Generic;

namespace PlusOne
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ArraysAreEqual(new int[] { 1, 2, 4 }, new Solution().PlusOne(new[] { 1, 2, 3 })));
            Console.WriteLine(ArraysAreEqual(new int[] { 1, 0, 0, 0 }, new Solution().PlusOne(new[] { 9, 9, 9 })));
        }

        private static bool ArraysAreEqual(int[] arrayA, int[] arrayB)
        {
            if (arrayA.Length != arrayB.Length)
            {
                return false;
            }

            for (var i = 0; i < arrayA.Length; i++)
            {
                if (arrayA[i] != arrayB[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        var list = new List<int>(digits);
        var addOne = true;
        
        for (var i = digits.Length - 1; i >= 0; i--)
        {
            if (addOne)
            {
                list[i] += 1;
                addOne = false;
            }

            if (list[i] >= 10)
            {
                list[i] = 0;
                addOne = true;
            }
        }

        if (addOne)
        {
            list.Insert(0, 1);
        }

        return list.ToArray();
    }
}