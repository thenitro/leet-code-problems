using System;

namespace IntToRoman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("III" == new Solution().IntToRoman(3));
            Console.WriteLine("IV" == new Solution().IntToRoman(4));
            Console.WriteLine("IX" == new Solution().IntToRoman(9));
            Console.WriteLine("LVIII" == new Solution().IntToRoman(58));
            Console.WriteLine("MCMXCIV" == new Solution().IntToRoman(1994));
        }
    }
}

public class Solution {
    public string IntToRoman(int num)
    {
        var result = string.Empty;
        
        var thousands = (int) num / 1000;
        result = AddSymbol(result, 'M', thousands);

        num -= thousands * 1000;

        var hundreds = (int) (num) / 100;
        result = AddTens(result, hundreds, 'M', 'D', 'C');

        num -= hundreds * 100;
        
        var tens = (int) (num) / 10;
        result = AddTens(result, tens, 'C', 'L', 'X');

        num -= tens * 10;

        result = AddTens(result, num, 'X', 'V', 'I');

        return result;
    }

    private string AddTens(string result, int amount, char tens, char single, char increment)
    {
        if (amount == 9)
        {
            result = AddSymbol(result, increment, 1);
            result = AddSymbol(result, tens, 1);
        } 
        else if (amount > 5 && amount < 9)
        {
            result = AddSymbol(result, single, 1);
            result = AddSymbol(result, increment, amount - 5);
        } 
        else if (amount == 5)
        {
            result = AddSymbol(result, single, 1);
        }
        else if (amount == 4)
        {
            result = AddSymbol(result, increment, 1);
            result = AddSymbol(result, single, 1);
        }
        else if (amount > 0 && amount < 4)
        {
            result = AddSymbol(result, increment, amount);
        }

        return result;
    }

    private string AddSymbol(string result, char c, int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            result += c;
        }

        return result;
    }
}