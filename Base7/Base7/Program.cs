using System;

namespace Base7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("202" == new Solution().ConvertToBase7(100));
            Console.WriteLine("-10" == new Solution().ConvertToBase7(-7));
        }
    }
}

public class Solution
{
    public string ConvertToBase7(int num)
    {
        if (num < 0)
        {
            return '-' + ConvertToBase7(-num);
        }

        if (num < 7)
        {
            return num + "";
        }

        return ConvertToBase7(num / 7) + num % 7;
    }
}