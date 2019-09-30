using System;
using System.Collections.Generic;

namespace NextGreaterElement3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(21 == new Solution().NextGreaterElement(12));
            Console.WriteLine(132 == new Solution().NextGreaterElement(123));
            Console.WriteLine(-1 == new Solution().NextGreaterElement(21));
        }
    }
}

public class Solution
{
    public int NextGreaterElement(int n)
    {
        var number = n.ToString().ToCharArray();

        var i = 0;
        for (i = number.Length - 1; i > 0; i--)
        {
            if (number[i - 1] < number[i])
            {
                break;
            }
        }

        if (i == 0)
        {
            return -1;
        }

        var x = number[i - 1];
        var smallest = i;

        for (var j = i + 1; j < number.Length; j++)
        {
            if (number[j] > x && number[j] <= number[smallest])
            {
                smallest = j;
            } 
        }

        var temp = number[i - 1];
        number[i - 1] = number[smallest];
        number[smallest] = temp;
        
        Array.Sort(number, i, number.Length - i);

        var val = Convert.ToInt64(new string(number));
        return (int)(val <= int.MaxValue ? val : -1);
    }
}