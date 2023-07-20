using System;
using System.Collections.Generic;

public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }
        
        var numbers = new List<int>();

        while (x > 0)
        {
            var number = x % 10;
            x /= 10;
            
            numbers.Add(number);
        }

        var index = 0;
        var center = Math.Ceiling(numbers.Count / 2.0);

        while (index < center)
        {
            var left = numbers[index];
            var right = numbers[numbers.Count - 1 - index];

            if (left != right)
            {
                return false;
            }

            index++;
        }

        return true;
    }
}