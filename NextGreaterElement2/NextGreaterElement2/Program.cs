using System;

namespace NextGreaterElement2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().NextGreaterElements(new[] {1, 2, 1});
            Console.WriteLine(string.Join(",", result));
        }
    }
}

public class Solution
{
    public int[] NextGreaterElements(int[] nums)
    {
        var result = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = -1;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            var j = i;
            
            var didCircle = false;
            var overflow = false;

            Console.WriteLine("i " + i);

            var numberA = nums[i];
            
            while (didCircle == false)
            {
                j++;

                if (j >= nums.Length)
                {
                    j = 0;
                    overflow = true;
                }

                if (overflow && j >= i)
                {
                    didCircle = true;
                }
                else
                {
                    var numberB = nums[j];

                    if (numberB > numberA)
                    {
                        result[i] = numberB;
                        break;
                    }
                    
                    Console.WriteLine("j " + j);
                }
            }
        }

        return result;
    }
}