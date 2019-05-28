﻿using System;

namespace AddBinary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("100" == new Solution().AddBinary("11", "1"));
            Console.WriteLine("10101" == new Solution().AddBinary("1010", "1011"));
            Console.WriteLine("1010" == new Solution().AddBinary("111", "11"));
        }
    }
}

public class Solution {
    public string AddBinary(string a, string b)
    {
        var result = string.Empty;
        var addOne = false;
        
        while (!string.IsNullOrEmpty(a) || !string.IsNullOrEmpty(b))
        {
            var preResult = '0';
            var addOneNow = addOne;

            addOne = false;
            
            var charA = a.Length > 0 ? a[a.Length - 1] : '0';
            if (a.Length > 0)
            {
                a = a.Remove(a.Length - 1);                
            }
            var charB = b.Length > 0 ? b[b.Length - 1] : '0';
            if (b.Length > 0)
            {
                b = b.Remove(b.Length - 1);                
            }
            
            //Console.WriteLine(charA + " " + charB);
            
            if (charA == '1' && charB == '1')
            {
                addOne = true;
            } 
            else if (charA == '0' && charB == '0')
            {
            }
            else
            {
                preResult = '1';
            }

            //Console.WriteLine(addOne + " " + addOneNow);
            
            if (addOneNow)
            {
                if (preResult == '0')
                {
                    preResult = '1';
                }
                else
                {
                    preResult = '0';
                    addOne = true;
                }
            }
            
            result = preResult + result;
            
            //Console.WriteLine(preResult);
            //Console.WriteLine("------");
        }

        if (addOne)
        {
            result = '1' + result;
        }
        
        //Console.WriteLine(result);

        return result;
    }
}