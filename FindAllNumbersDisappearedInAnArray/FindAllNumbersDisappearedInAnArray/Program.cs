using System;
using System.Collections.Generic;

namespace FindAllNumbersDisappearedInAnArray
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().FindDisappearedNumbers(new[] {4, 3, 2, 7, 8, 2, 3, 1});
            Console.WriteLine(string.Join(",", result));
            
            var result2 = new Solution().FindDisappearedNumbers(new[] {1, 1});
            Console.WriteLine(string.Join(",", result2));
        }
    }
}

public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var result = new List<int>();
        var set = new HashSet<int>();

        foreach (var num in nums)
        {
            set.Add(num);
        }

        for (var i = 1; i <= nums.Length; i++)
        {
            if (set.Contains(i))
            {
                continue;
            }
            
            result.Add(i);
        }

        return result;
    }
}