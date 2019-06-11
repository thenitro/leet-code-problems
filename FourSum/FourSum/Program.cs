using System;
using System.Collections.Generic;

namespace FourSum
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Solution().FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);
            
            Console.WriteLine();
            
            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                
                Console.WriteLine();
            }
            
            result = new Solution().FourSum(new int[] { 0, 0, 0, 0 }, 0);
            
            Console.WriteLine();
            
            foreach (var i in result)
            {
                foreach (var j in i)
                {
                    Console.Write(j + " ");
                }
                
                Console.WriteLine();
            }
            
            result = new Solution().FourSum(new int[] { -5,5,4,-3,0,0,4,-2}, 4);
            
            Console.WriteLine();
            
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
    public IList<IList<int>> FourSum(int[] nums, int target) {
        Array.Sort(nums);
        
        var results = new List<IList<int>>();

        for (var i = 0; i < nums.Length - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            
            var a = nums[i];
            
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                
                var d = nums[j];

                var l = j + 1;
                var r = nums.Length - 1;

                while (l < r)
                {
                    
                    var b = nums[l];
                    var c = nums[r];
                    
                    var sum = a + b + c + d;

                    if (sum > target)
                    {
                        r--;
                    } else if (sum < target)
                    {
                        l++;
                    }
                    else
                    {
                        results.Add(new List<int>() { a, b, c, d });

                        while (l < r && nums[l] == nums[l + 1])
                        {
                            l++;
                        }
                        
                        while (l < r && nums[r] == nums[r - 1])
                        {
                            r--;
                        }

                        l++;
                        r--;
                    }
                }
            }
        }

        return results;
    }
}