using System;

namespace TwoSumII
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().TwoSum(new int[] {2, 7, 11, 15}, 9);

            foreach (var i in result)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
            
            var result2 = new Solution().TwoSum(new int[] {3,24,50,79,88,150,345}, 200);
            
            foreach (var i in result2)
            {
                Console.Write(i + " ");
            }
            
            Console.WriteLine();
        }
    }
}

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var l = 0;
        var r = numbers.Length - 1;

        while (l < r)
        {
            var sum = numbers[l] + numbers[r];
            
            if (sum > target)
            {
                r--;
            }
            else if (sum < target)
            {
                l++;
            }
            else
            {
                return new int[] { l + 1, r + 1 };
            }
        }
        
        return new int[0];
    }
}