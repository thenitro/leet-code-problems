using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfectNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().CheckPerfectNumber(28));
            Console.WriteLine(false == new Solution().CheckPerfectNumber(36));
            Console.WriteLine(false == new Solution().CheckPerfectNumber(2));
            Console.WriteLine(false == new Solution().CheckPerfectNumber(3));
            Console.WriteLine(false == new Solution().CheckPerfectNumber(0));
        }
    }
}

public class Solution
{
    public bool CheckPerfectNumber(int num)
    {
        if (num < 3 || num % 2 == 1)
        {
            return false;
        }

        var origin = num;
        var sum = 0;

        while (num > 1)
        {
            num = (int)Math.Ceiling(num / 2.0);
            sum += num;
        }
        
        return sum == origin;
    }
}

public class SolutionSlow
{
    public bool CheckPerfectNumber(int num)
    {
        if (num == 2 || num % 2 == 1)
        {
            return false;
        }

        return CheckPerfectNumberHelper(num, (int)Math.Ceiling(num / 2.0), new List<int>());
    }

    private bool CheckPerfectNumberHelper(int origin, int num, List<int> sums)
    {
        Console.WriteLine(num);
        
        if (num == 0)
        {
            return false;
        }

        sums.Add(num);
        
        if (num == 1)
        {
            return sums.Sum() == origin;
        }

        return CheckPerfectNumberHelper(origin, (int)Math.Ceiling(num / 2.0), sums);
    }
}