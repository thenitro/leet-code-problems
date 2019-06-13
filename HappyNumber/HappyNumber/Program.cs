using System;
using System.Collections.Generic;

namespace HappyNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsHappy(19));
        }
    }
}

public class Solution {
    public bool IsHappy(int n)
    {
        var memo = new HashSet<int>();

        while (true)
        {
            var numbers = SplitNumbers(n);
            
            n = 0;

            for (var i = 0; i < numbers.Count; i++)
            {
                var number = numbers[i]; 
                n += number * number; 
            }

            if (memo.Contains(n)) return false;
            if (n == 1) return true;

            memo.Add(n);
        }

        return false;
    }

    private List<int> SplitNumbers(int n)
    {
        var list = new List<int>();

        while (n > 0)
        {
            list.Add(n % 10);
            n = n / 10;
        }

        return list;
    }
}