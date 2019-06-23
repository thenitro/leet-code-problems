using System;

namespace UglyNumber
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(true == new Solution().IsUgly(6));
            Console.WriteLine(true == new Solution().IsUgly(8));
            Console.WriteLine(false == new Solution().IsUgly(14));
            Console.WriteLine(false == new Solution().IsUgly(0));
        }
    }
}

public class Solution
{
    public bool IsUgly(int num)
    {
        while (num > 0)
        {
            if (num == 1)
            {
                return true;
            }
        
            if (num % 2 == 0)
            {
                num = num / 2;
            } else if (num % 3 == 0)
            {
                num = num / 3;
            } else if (num % 5 == 0)
            {
                num = num / 5;
            }
            else
            {
                break;
            }
        }        

        return false;
    }    
}